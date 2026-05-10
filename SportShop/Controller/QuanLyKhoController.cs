using SportShop.DataBase;
using SportShop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SportShop.Controller
{
    public class QuanLyKhoController
    {
        // ==========================================
        // 1. QUẢN LÝ PHIẾU NHẬP HÀNG (IMPORT ORDER)
        // ==========================================

        // Lấy danh sách tất cả phiếu nhập
        public List<ImportOrder> GetAllImportOrders()
        {
            const string sql = @"
                SELECT io.Id, io.SupplierId, s.Name AS SupplierName, 
                       io.UserId, u.FullName AS UserName, 
                       io.ImportDate, io.TotalAmount, io.Notes, 
                       io.Status -- Đã bổ sung cột Status
                FROM ImportOrder io
                LEFT JOIN Supplier s ON io.SupplierId = s.Id
                LEFT JOIN [User] u ON io.UserId = u.Id
                ORDER BY io.Id DESC";

            DataTable dt = DBConnection.GetDataTable(sql);
            return ConvertToImportOrderList(dt);
        }

        // 👉 BƯỚC 1 & 2: LƯU NHÁP PHIẾU NHẬP (Chưa cộng tồn kho)
        public bool SaveDraftImportOrder(ImportOrder importOrder, List<ImportOrderDetail> details)
        {
            using (SqlConnection conn = DBConnection.GetDBConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Thêm ImportOrder với Status = 'DRAFT'
                        const string sqlImport = @"
                            INSERT INTO ImportOrder (SupplierId, UserId, ImportDate, TotalAmount, Notes, Status) 
                            OUTPUT INSERTED.Id 
                            VALUES (@sid, @uid, @date, @total, @notes, 'DRAFT')";

                        int newId;
                        using (var cmdImport = new SqlCommand(sqlImport, conn, trans))
                        {
                            cmdImport.Parameters.Add(new SqlParameter("@sid", SqlDbType.Int) { Value = importOrder.SupplierId });
                            cmdImport.Parameters.Add(new SqlParameter("@uid", SqlDbType.Int) { Value = importOrder.UserId });
                            cmdImport.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime) { Value = importOrder.ImportDate ?? DateTime.Now });
                            cmdImport.Parameters.Add(new SqlParameter("@total", SqlDbType.Decimal) { Value = importOrder.TotalAmount ?? 0m });
                            cmdImport.Parameters.Add(new SqlParameter("@notes", SqlDbType.NVarChar) { Value = (object)importOrder.Notes ?? DBNull.Value });

                            newId = Convert.ToInt32(cmdImport.ExecuteScalar());
                        }

                        // 2. Lưu chi tiết phiếu nhập (KHÔNG update ProductVariant, KHÔNG ghi Log)
                        foreach (var item in details)
                        {
                            const string sqlDetail = "INSERT INTO ImportOrderDetail (ImportOrderId, ProductVariantId, Quantity, ImportPrice) VALUES (@iid, @pvid, @qty, @price)";
                            using (var cmdDetail = new SqlCommand(sqlDetail, conn, trans))
                            {
                                cmdDetail.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int) { Value = newId });
                                cmdDetail.Parameters.Add(new SqlParameter("@pvid", SqlDbType.Int) { Value = item.ProductVariantId });
                                cmdDetail.Parameters.Add(new SqlParameter("@qty", SqlDbType.Int) { Value = item.Quantity });
                                cmdDetail.Parameters.Add(new SqlParameter("@price", SqlDbType.Decimal) { Value = item.ImportPrice });
                                cmdDetail.ExecuteNonQuery();
                            }
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

        // 👉 BƯỚC 4: XÁC NHẬN NHẬP KHO (COMMIT IMPORT)
        public bool CommitImportOrder(int importOrderId, int currentUserId)
        {
            using (SqlConnection conn = DBConnection.GetDBConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Kiểm tra xem phiếu có tồn tại và đang ở trạng thái DRAFT không (Không đổi)
                        const string sqlCheck = "SELECT Status FROM ImportOrder WHERE Id = @id";
                        string status = "";
                        using (var cmdCheck = new SqlCommand(sqlCheck, conn, trans))
                        {
                            cmdCheck.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = importOrderId });
                            var result = cmdCheck.ExecuteScalar();
                            if (result == null) throw new Exception("Không tìm thấy phiếu nhập");
                            status = result.ToString();
                        }

                        if (status == "COMPLETED")
                            throw new Exception("Phiếu nhập này đã được hoàn tất trước đó!");

                        // 2. Lấy danh sách chi tiết phiếu nhập (👉 Đã thêm ImportPrice vào câu SELECT)
                        List<ImportOrderDetail> details = new List<ImportOrderDetail>();
                        const string sqlGetDetails = "SELECT ProductVariantId, Quantity, ImportPrice FROM ImportOrderDetail WHERE ImportOrderId = @id";
                        using (var cmdGetDetails = new SqlCommand(sqlGetDetails, conn, trans))
                        {
                            cmdGetDetails.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = importOrderId });
                            using (var reader = cmdGetDetails.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    details.Add(new ImportOrderDetail
                                    {
                                        ProductVariantId = Convert.ToInt32(reader["ProductVariantId"]),
                                        Quantity = Convert.ToInt32(reader["Quantity"]),
                                        ImportPrice = Convert.ToDecimal(reader["ImportPrice"]) // 👉 Lấy thêm Giá nhập
                                    });
                                }
                            }
                        }

                        // 3. Tiến hành cập nhật tồn kho, TÍNH GIÁ VỐN và ghi Log
                        foreach (var item in details)
                        {
                            // A. Cập nhật Giá Vốn Bình Quân (MAC) và Cộng số lượng vào kho
                            const string sqlUpdateStock = @"
                        UPDATE ProductVariant 
                        SET 
                            CostPrice = CASE 
                                WHEN (Quantity + @qty) > 0 
                                THEN ((Quantity * CostPrice) + (@qty * @price)) / (Quantity + @qty)
                                ELSE @price 
                            END,
                            Quantity = Quantity + @qty 
                        WHERE Id = @pvid";

                            using (var cmdStock = new SqlCommand(sqlUpdateStock, conn, trans))
                            {
                                cmdStock.Parameters.Add(new SqlParameter("@qty", SqlDbType.Int) { Value = item.Quantity });
                                cmdStock.Parameters.Add(new SqlParameter("@price", SqlDbType.Decimal) { Value = item.ImportPrice }); // 👉 Truyền giá nhập vào công thức
                                cmdStock.Parameters.Add(new SqlParameter("@pvid", SqlDbType.Int) { Value = item.ProductVariantId });
                                cmdStock.ExecuteNonQuery();
                            }

                            // B. Ghi Log Tồn Kho (Không đổi)
                            const string sqlLog = "INSERT INTO InventoryLog (ProductVariantId, ChangeAmount, Type, ImportOrderId, UserId, Notes) VALUES (@pvid, @change, 'IMPORT', @iid, @uid, N'Chốt phiếu nhập hàng')";
                            using (var cmdLog = new SqlCommand(sqlLog, conn, trans))
                            {
                                cmdLog.Parameters.Add(new SqlParameter("@pvid", SqlDbType.Int) { Value = item.ProductVariantId });
                                cmdLog.Parameters.Add(new SqlParameter("@change", SqlDbType.Int) { Value = item.Quantity });
                                cmdLog.Parameters.Add(new SqlParameter("@iid", SqlDbType.Int) { Value = importOrderId });
                                cmdLog.Parameters.Add(new SqlParameter("@uid", SqlDbType.Int) { Value = currentUserId });
                                cmdLog.ExecuteNonQuery();
                            }
                        }

                        // 4. Chuyển trạng thái phiếu nhập thành COMPLETED (Không đổi)
                        const string sqlComplete = "UPDATE ImportOrder SET Status = 'COMPLETED', ImportDate = GETDATE() WHERE Id = @id";
                        using (var cmdComplete = new SqlCommand(sqlComplete, conn, trans))
                        {
                            cmdComplete.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = importOrderId });
                            cmdComplete.ExecuteNonQuery();
                        }

                        trans.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        try { trans.Rollback(); } catch { }
                        return false;
                    }
                }
            }
        }
        // Xóa phiếu nhập (CHỈ CHO PHÉP XÓA KHI ĐANG LÀ DRAFT)
        public bool DeleteImportOrder(int importOrderId)
        {
            using (SqlConnection conn = DBConnection.GetDBConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        const string sqlCheck = "SELECT Status FROM ImportOrder WHERE Id = @id";
                        string status = "";
                        using (var cmdCheck = new SqlCommand(sqlCheck, conn, trans))
                        {
                            cmdCheck.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = importOrderId });
                            status = cmdCheck.ExecuteScalar()?.ToString();
                        }

                        if (status == "COMPLETED")
                            throw new Exception("Không thể xóa phiếu đã nhập kho thành công. Vui lòng làm phiếu Xuất Hủy nếu cần.");

                        // Xóa chi tiết
                        const string sqlDelDetail = "DELETE FROM ImportOrderDetail WHERE ImportOrderId = @id";
                        using (var cmdDelDet = new SqlCommand(sqlDelDetail, conn, trans))
                        {
                            cmdDelDet.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = importOrderId });
                            cmdDelDet.ExecuteNonQuery();
                        }

                        // Xóa phiếu chính
                        const string sqlDelOrder = "DELETE FROM ImportOrder WHERE Id = @id";
                        using (var cmdDelOrder = new SqlCommand(sqlDelOrder, conn, trans))
                        {
                            cmdDelOrder.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = importOrderId });
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

        // Lấy chi tiết của 1 phiếu nhập
        public List<ImportOrderDetail> GetImportOrderDetails(int importOrderId)
        {
            const string sql = @"
                SELECT iod.Id, iod.ImportOrderId, iod.ProductVariantId, 
                       iod.Quantity, iod.ImportPrice,
                       p.Name AS ProductName, s.Name AS SizeName, c.Name AS ColorName
                FROM ImportOrderDetail iod
                LEFT JOIN ProductVariant pv ON iod.ProductVariantId = pv.Id
                LEFT JOIN Product p ON pv.ProductId = p.Id
                LEFT JOIN Size s ON pv.SizeId = s.Id
                LEFT JOIN Color c ON pv.ColorId = c.Id
                WHERE iod.ImportOrderId = @iid";

            var p = new SqlParameter("@iid", SqlDbType.Int) { Value = importOrderId };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { p });

            var list = new List<ImportOrderDetail>();
            foreach (DataRow row in dt.Rows)
            {
                var productName = row["ProductName"] == DBNull.Value ? "" : row["ProductName"].ToString();
                var sizeName = row["SizeName"] == DBNull.Value ? "" : row["SizeName"].ToString();
                var colorName = row["ColorName"] == DBNull.Value ? "" : row["ColorName"].ToString();

                list.Add(new ImportOrderDetail
                {
                    Id = Convert.ToInt32(row["Id"]),
                    ImportOrderId = Convert.ToInt32(row["ImportOrderId"]),
                    ProductVariantId = Convert.ToInt32(row["ProductVariantId"]),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    ImportPrice = Convert.ToDecimal(row["ImportPrice"]),
                    VariantDisplayName = $"{productName} - {sizeName} - {colorName}"
                });
            }
            return list;
        }

        // ==========================================
        // 2. LỊCH SỬ TỒN KHO (INVENTORY LOG)
        // ==========================================
        public List<InventoryLog> GetAllInventoryLogs()
        {
            const string sql = @"
                SELECT il.Id, il.ProductVariantId, il.ChangeAmount, il.Type, 
                       il.OrderId, il.ImportOrderId, il.UserId, il.Notes, il.CreatedAt,
                       p.Name AS ProductName, s.Name AS SizeName, c.Name AS ColorName,
                       u.FullName AS UserName
                FROM InventoryLog il
                LEFT JOIN ProductVariant pv ON il.ProductVariantId = pv.Id
                LEFT JOIN Product p ON pv.ProductId = p.Id
                LEFT JOIN Size s ON pv.SizeId = s.Id
                LEFT JOIN Color c ON pv.ColorId = c.Id
                LEFT JOIN [User] u ON il.UserId = u.Id
                ORDER BY il.Id DESC";

            DataTable dt = DBConnection.GetDataTable(sql);
            var list = new List<InventoryLog>();

            foreach (DataRow row in dt.Rows)
            {
                var productName = row["ProductName"] == DBNull.Value ? "" : row["ProductName"].ToString();
                var sizeName = row["SizeName"] == DBNull.Value ? "" : row["SizeName"].ToString();
                var colorName = row["ColorName"] == DBNull.Value ? "" : row["ColorName"].ToString();

                list.Add(new InventoryLog
                {
                    Id = Convert.ToInt32(row["Id"]),
                    ProductVariantId = Convert.ToInt32(row["ProductVariantId"]),
                    ChangeAmount = Convert.ToInt32(row["ChangeAmount"]),
                    Type = row["Type"].ToString(),
                    OrderId = row["OrderId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["OrderId"]),
                    ImportOrderId = row["ImportOrderId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["ImportOrderId"]),
                    UserId = row["UserId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["UserId"]),
                    Notes = row["Notes"] == DBNull.Value ? "" : row["Notes"].ToString(),
                    CreatedAt = row["CreatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["CreatedAt"]),

                    VariantDisplayName = $"{productName} - {sizeName} - {colorName}",
                    UserName = row["UserName"] == DBNull.Value ? "" : row["UserName"].ToString()
                });
            }
            return list;
        }
        public List<ImportOrder> FilterImportOrders(
    DateTime fromDate,
    DateTime toDate,
    string status = "COMPLETED")
        {
            string sql = @"
        SELECT io.Id, io.SupplierId, s.Name AS SupplierName,
               io.UserId, u.FullName AS UserName,
               io.ImportDate, io.TotalAmount,
               io.Notes, io.Status
        FROM ImportOrder io
        LEFT JOIN Supplier s ON io.SupplierId = s.Id
        LEFT JOIN [User] u ON io.UserId = u.Id
        WHERE CAST(io.ImportDate AS DATE) 
              BETWEEN @fromDate AND @toDate";

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@fromDate", SqlDbType.Date)
            {
                Value = fromDate.Date
            });

            parameters.Add(new SqlParameter("@toDate", SqlDbType.Date)
            {
                Value = toDate.Date
            });

            // Chỉ lọc status nếu có truyền vào
            if (!string.IsNullOrEmpty(status))
            {
                sql += " AND io.Status = @status";

                parameters.Add(new SqlParameter("@status", SqlDbType.NVarChar)
                {
                    Value = status
                });
            }

            sql += " ORDER BY io.Id DESC";

            DataTable dt = DBConnection.GetDataTable(sql, parameters.ToArray());

            return ConvertToImportOrderList(dt);
        }

        // ==========================================
        // HÀM HELPER
        // ==========================================
        private List<ImportOrder> ConvertToImportOrderList(DataTable dt)
        {
            var list = new List<ImportOrder>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ImportOrder
                {
                    Id = Convert.ToInt32(row["Id"]),
                    SupplierId = Convert.ToInt32(row["SupplierId"]),
                    SupplierName = row["SupplierName"] == DBNull.Value ? "" : row["SupplierName"].ToString(),
                    UserId = Convert.ToInt32(row["UserId"]),
                    UserName = row["UserName"] == DBNull.Value ? "" : row["UserName"].ToString(),
                    ImportDate = row["ImportDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["ImportDate"]),
                    TotalAmount = row["TotalAmount"] == DBNull.Value ? 0m : Convert.ToDecimal(row["TotalAmount"]),
                    Notes = row["Notes"] == DBNull.Value ? "" : row["Notes"].ToString(),

                    // Thêm thuộc tính này vào Model ImportOrder.cs nhé: public string Status { get; set; }
                    Status = row.Table.Columns.Contains("Status") && row["Status"] != DBNull.Value ? row["Status"].ToString() : "DRAFT"
                });
            }
            return list;
        }
    }
}