using SportShop.DataBase;
using SportShop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SportShop.Controller
{
    public class QuanLyHoaDonController
    {
        // 1. LẤY TẤT CẢ HÓA ĐƠN
        public List<Order> GetAllOrders()
        {
            const string sql = @"
                SELECT o.Id, o.OrderCode, o.CustomerId, c.Name AS CustomerName, 
                       o.UserId, u.FullName AS StaffName, o.OrderDate, 
                       o.Subtotal, o.DiscountAmount, o.TotalAmount, o.PaymentMethod, o.Notes
                FROM Orders o
                LEFT JOIN [User] u ON o.UserId = u.Id
                LEFT JOIN Customer c ON o.CustomerId = c.Id
                ORDER BY o.Id DESC";

            DataTable dt = DBConnection.GetDataTable(sql);
            return ConvertToOrderList(dt);
        }

        // 2. LẤY HÓA ĐƠN THEO ID
        public Order GetOrderById(int id)
        {
            const string sql = @"
                SELECT o.Id, o.OrderCode, o.CustomerId, c.Name AS CustomerName, 
                       o.UserId, u.FullName AS StaffName, o.OrderDate, 
                       o.Subtotal, o.DiscountAmount, o.TotalAmount, o.PaymentMethod, o.Notes
                FROM Orders o
                LEFT JOIN [User] u ON o.UserId = u.Id
                LEFT JOIN Customer c ON o.CustomerId = c.Id
                WHERE o.Id = @id";

            var p = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { p });
            var list = ConvertToOrderList(dt);

            return list.Count > 0 ? list[0] : null;
        }

        // 3. THÊM HÓA ĐƠN 

        // 3. THÊM HÓA ĐƠN 
        // 👉 ĐÃ FIX: Thêm tham số appliedVoucherId để lưu vào bảng OrderVoucher
        public int AddOrder(Order order, List<OrderDetail> orderDetails, int? appliedVoucherId = null)
        {
            using (SqlConnection conn = DBConnection.GetDBConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 3.1 Thêm Hóa đơn và lấy Id vừa tạo
                        const string sqlOrder = @"
            INSERT INTO Orders (CustomerId, UserId, OrderDate, Subtotal, DiscountAmount, TotalAmount, PaymentMethod, Notes) 
            OUTPUT INSERTED.Id 
            VALUES (@cid, @uid, @date, @subtotal, @discount, @total, @payment, @notes)";

                        int newOrderId;
                        using (var cmdOrder = new SqlCommand(sqlOrder, conn, trans))
                        {
                            cmdOrder.Parameters.Add(new SqlParameter("@cid", SqlDbType.Int) { Value = (object)order.CustomerId ?? DBNull.Value });
                            cmdOrder.Parameters.Add(new SqlParameter("@uid", SqlDbType.Int) { Value = order.UserId });
                            cmdOrder.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime) { Value = order.OrderDate ?? DateTime.Now });

                            // Truyền đầy đủ tiền vào SQL
                            cmdOrder.Parameters.Add(new SqlParameter("@subtotal", SqlDbType.Decimal) { Value = order.Subtotal ?? 0m });
                            cmdOrder.Parameters.Add(new SqlParameter("@discount", SqlDbType.Decimal) { Value = order.DiscountAmount ?? 0m });
                            cmdOrder.Parameters.Add(new SqlParameter("@total", SqlDbType.Decimal) { Value = order.TotalAmount ?? 0m });

                            cmdOrder.Parameters.Add(new SqlParameter("@payment", SqlDbType.NVarChar) { Value = order.PaymentMethod ?? "Tiền mặt" });
                            cmdOrder.Parameters.Add(new SqlParameter("@notes", SqlDbType.NVarChar) { Value = (object)order.Notes ?? DBNull.Value });

                            // Lấy ID vừa được tạo bằng OUTPUT INSERTED.Id
                            newOrderId = Convert.ToInt32(cmdOrder.ExecuteScalar());
                        }

                        // 3.2 Lặp qua từng chi tiết đơn hàng
                        foreach (var item in orderDetails)
                        {
                            // Lưu chi tiết
                            const string sqlDetail = "INSERT INTO OrderDetail (OrderId, ProductVariantId, Quantity, UnitPrice) VALUES (@oid, @pvid, @qty, @uprice)";
                            using (var cmdDetail = new SqlCommand(sqlDetail, conn, trans))
                            {
                                cmdDetail.Parameters.Add(new SqlParameter("@oid", SqlDbType.Int) { Value = newOrderId });
                                cmdDetail.Parameters.Add(new SqlParameter("@pvid", SqlDbType.Int) { Value = item.ProductVariantId });
                                cmdDetail.Parameters.Add(new SqlParameter("@qty", SqlDbType.Int) { Value = item.Quantity });
                                cmdDetail.Parameters.Add(new SqlParameter("@uprice", SqlDbType.Decimal) { Value = item.UnitPrice });
                                cmdDetail.ExecuteNonQuery();
                            }

                            // Trừ tồn kho
                            const string sqlUpdateStock = "UPDATE ProductVariant SET Quantity = Quantity - @qty WHERE Id = @pvid";
                            using (var cmdStock = new SqlCommand(sqlUpdateStock, conn, trans))
                            {
                                cmdStock.Parameters.Add(new SqlParameter("@qty", SqlDbType.Int) { Value = item.Quantity });
                                cmdStock.Parameters.Add(new SqlParameter("@pvid", SqlDbType.Int) { Value = item.ProductVariantId });
                                cmdStock.ExecuteNonQuery();
                            }

                            // Ghi log tồn kho
                            const string sqlLog = "INSERT INTO InventoryLog (ProductVariantId, ChangeAmount, Type, OrderId, UserId, Notes) VALUES (@pvid, @change, 'EXPORT', @oid, @uid, N'Xuất bán hàng')";
                            using (var cmdLog = new SqlCommand(sqlLog, conn, trans))
                            {
                                cmdLog.Parameters.Add(new SqlParameter("@pvid", SqlDbType.Int) { Value = item.ProductVariantId });
                                cmdLog.Parameters.Add(new SqlParameter("@change", SqlDbType.Int) { Value = item.Quantity });
                                cmdLog.Parameters.Add(new SqlParameter("@oid", SqlDbType.Int) { Value = newOrderId });
                                cmdLog.Parameters.Add(new SqlParameter("@uid", SqlDbType.Int) { Value = order.UserId });
                                cmdLog.ExecuteNonQuery();
                            }
                        }

                        // =========================================================
                        // 3.3 LƯU VẾT VOUCHER VÀO BẢNG OrderVoucher (NẾU CÓ)
                        // =========================================================
                        if (appliedVoucherId.HasValue && appliedVoucherId.Value > 0)
                        {
                            const string sqlOrderVoucher = "INSERT INTO OrderVoucher (OrderId, VoucherId, AppliedDate) VALUES (@oid, @vid, GETDATE())";
                            using (var cmdVoucher = new SqlCommand(sqlOrderVoucher, conn, trans))
                            {
                                cmdVoucher.Parameters.Add(new SqlParameter("@oid", SqlDbType.Int) { Value = newOrderId });
                                cmdVoucher.Parameters.Add(new SqlParameter("@vid", SqlDbType.Int) { Value = appliedVoucherId.Value });
                                cmdVoucher.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();

                        // Trả về Mã ID của hóa đơn để View bắt lấy và truyền sang file in PDF
                        return newOrderId;
                    }
                    catch
                    {
                        try { trans.Rollback(); } catch { }

                        //  Nếu lỗi thì trả về -1 thay vì false
                        return -1;
                    }
                }
            }
        }

        // 4. SỬA HÓA ĐƠN (ĐÃ FIX: Bổ sung Subtotal và TotalAmount)
        public bool UpdateOrder(Order order)
        {
            const string sql = @"
                UPDATE Orders 
                SET CustomerId = @cid, 
                    Subtotal = @subtotal,
                    DiscountAmount = @discount, 
                    TotalAmount = @total,
                    PaymentMethod = @payment, 
                    Notes = @notes, 
                    UpdatedAt = GETDATE() 
                WHERE Id = @id";

            var parameters = new[]
            {
                new SqlParameter("@id", SqlDbType.Int) { Value = order.Id },
                new SqlParameter("@cid", SqlDbType.Int) { Value = (object)order.CustomerId ?? DBNull.Value },
                
                // 👉 Truyền tiền vào khi cập nhật
                new SqlParameter("@subtotal", SqlDbType.Decimal) { Value = order.Subtotal ?? 0m },
                new SqlParameter("@discount", SqlDbType.Decimal) { Value = order.DiscountAmount ?? 0m },
                new SqlParameter("@total", SqlDbType.Decimal) { Value = order.TotalAmount ?? 0m },

                new SqlParameter("@payment", SqlDbType.NVarChar) { Value = order.PaymentMethod ?? "Tiền mặt" },
                new SqlParameter("@notes", SqlDbType.NVarChar) { Value = (object)order.Notes ?? DBNull.Value }
            };

            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        // 5. XÓA HÓA ĐƠN 
        public bool DeleteOrder(int orderId)
        {
            using (SqlConnection conn = DBConnection.GetDBConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 5.1 Hoàn lại số lượng tồn kho dựa trên OrderDetail
                        const string sqlRestoreStock = @"
                            UPDATE pv 
                            SET pv.Quantity = pv.Quantity + od.Quantity
                            FROM ProductVariant pv
                            INNER JOIN OrderDetail od ON pv.Id = od.ProductVariantId
                            WHERE od.OrderId = @id";
                        using (var cmdRestore = new SqlCommand(sqlRestoreStock, conn, trans))
                        {
                            cmdRestore.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = orderId });
                            cmdRestore.ExecuteNonQuery();
                        }

                        // 5.2 Xóa Log tồn kho
                        const string sqlDelLog = "DELETE FROM InventoryLog WHERE OrderId = @id";
                        using (var cmdDelLog = new SqlCommand(sqlDelLog, conn, trans))
                        {
                            cmdDelLog.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = orderId });
                            cmdDelLog.ExecuteNonQuery();
                        }

                        // 5.3 Xóa Voucher áp dụng
                        const string sqlDelVoucher = "DELETE FROM OrderVoucher WHERE OrderId = @id";
                        using (var cmdDelVoucher = new SqlCommand(sqlDelVoucher, conn, trans))
                        {
                            cmdDelVoucher.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = orderId });
                            cmdDelVoucher.ExecuteNonQuery();
                        }

                        // 5.4 Xóa Chi tiết hóa đơn
                        const string sqlDelDetail = "DELETE FROM OrderDetail WHERE OrderId = @id";
                        using (var cmdDelDet = new SqlCommand(sqlDelDetail, conn, trans))
                        {
                            cmdDelDet.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = orderId });
                            cmdDelDet.ExecuteNonQuery();
                        }

                        // 5.5 Xóa Hóa đơn
                        const string sqlDelOrder = "DELETE FROM Orders WHERE Id = @id";
                        using (var cmdDelOrder = new SqlCommand(sqlDelOrder, conn, trans))
                        {
                            cmdDelOrder.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = orderId });
                            cmdDelOrder.ExecuteNonQuery();
                        }

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        try { trans.Rollback(); } catch { }
                        return false;
                    }
                }
            }
        }

        // 6. TÌM KIẾM HÓA ĐƠN
        public List<Order> SearchOrders(string keyword)
        {
            const string sql = @"
                SELECT o.Id, o.OrderCode, o.CustomerId, c.Name AS CustomerName, 
                       o.UserId, u.FullName AS StaffName, o.OrderDate, 
                       o.Subtotal, o.DiscountAmount, o.TotalAmount, o.PaymentMethod, o.Notes
                FROM Orders o
                LEFT JOIN [User] u ON o.UserId = u.Id
                LEFT JOIN Customer c ON o.CustomerId = c.Id
                WHERE o.OrderCode LIKE @key OR u.FullName LIKE @key OR c.Name LIKE @key
                ORDER BY o.Id DESC";

            var pKey = new SqlParameter("@key", SqlDbType.NVarChar, 200) { Value = "%" + keyword + "%" };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { pKey });

            return ConvertToOrderList(dt);
        }

        // 7. LẤY CHI TIẾT HÓA ĐƠN
        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            const string sql = @"
                SELECT od.Id, od.OrderId, od.ProductVariantId, 
                       od.Quantity, od.UnitPrice,
                       p.Name AS ProductName, s.Name AS SizeName, c.Name AS ColorName
                FROM OrderDetail od
                LEFT JOIN ProductVariant pv ON od.ProductVariantId = pv.Id
                LEFT JOIN Product p ON pv.ProductId = p.Id
                LEFT JOIN Size s ON pv.SizeId = s.Id
                LEFT JOIN Color c ON pv.ColorId = c.Id
                WHERE od.OrderId = @orderId";

            var p = new SqlParameter("@orderId", SqlDbType.Int) { Value = orderId };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { p });

            var list = new List<OrderDetail>();
            foreach (DataRow row in dt.Rows)
            {
                var productName = row["ProductName"] == DBNull.Value ? "" : row["ProductName"].ToString();
                var sizeName = row["SizeName"] == DBNull.Value ? "" : row["SizeName"].ToString();
                var colorName = row["ColorName"] == DBNull.Value ? "" : row["ColorName"].ToString();

                list.Add(new OrderDetail
                {
                    Id = Convert.ToInt32(row["Id"]),
                    OrderId = Convert.ToInt32(row["OrderId"]),
                    ProductVariantId = Convert.ToInt32(row["ProductVariantId"]),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                    VariantDisplayName = $"{productName} - {sizeName} - {colorName}"
                });
            }
            return list;
        }

        // ==========================================
        // HÀM HELPER: CHUYỂN DATATABLE SANG LIST MODEL
        // ==========================================
        private List<Order> ConvertToOrderList(DataTable dt)
        {
            var list = new List<Order>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Order
                {
                    Id = Convert.ToInt32(row["Id"]),
                    OrderCode = row["OrderCode"] == DBNull.Value ? "" : row["OrderCode"].ToString(),
                    CustomerId = row["CustomerId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["CustomerId"]),
                    CustomerName = row["CustomerName"] == DBNull.Value ? "" : row["CustomerName"].ToString(),
                    UserId = Convert.ToInt32(row["UserId"]),
                    StaffName = row["StaffName"] == DBNull.Value ? "" : row["StaffName"].ToString(),
                    OrderDate = row["OrderDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["OrderDate"]),
                    Subtotal = row["Subtotal"] == DBNull.Value ? 0m : Convert.ToDecimal(row["Subtotal"]),
                    DiscountAmount = row["DiscountAmount"] == DBNull.Value ? 0m : Convert.ToDecimal(row["DiscountAmount"]),
                    TotalAmount = row["TotalAmount"] == DBNull.Value ? 0m : Convert.ToDecimal(row["TotalAmount"]),
                    PaymentMethod = row["PaymentMethod"] == DBNull.Value ? "" : row["PaymentMethod"].ToString(),
                    Notes = row["Notes"] == DBNull.Value ? "" : row["Notes"].ToString()
                });
            }
            return list;
        }
    }
}