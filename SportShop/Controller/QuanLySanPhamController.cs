using SportShop.DataBase;
using SportShop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;

namespace SportShop.Controller
{
    public class QuanLySanPhamController
    {
        // ==========================================
        // 1. SẢN PHẨM (PRODUCT)
        // ==========================================

        public List<Product> GetAllProducts()
        {
            string sql = @"
                SELECT p.Id, p.SKU, p.Name, p.CategoryId, c.CategoryName, 
                       p.Description, p.BasePrice, p.ImagePath, p.IsActive
                FROM Product p
                LEFT JOIN Category c ON p.CategoryId = c.Id
                ORDER BY p.Id DESC";

            DataTable dt = DBConnection.GetDataTable(sql);
            return ConvertToProductList(dt);
        }

        public List<Product> SearchProducts(string keyword)
        {
            string sql = @"
                SELECT p.Id, p.SKU, p.Name, p.CategoryId, c.CategoryName, 
                       p.Description, p.BasePrice, p.ImagePath, p.IsActive
                FROM Product p
                LEFT JOIN Category c ON p.CategoryId = c.Id
                WHERE p.Name LIKE @keyword OR c.CategoryName LIKE @keyword OR p.SKU LIKE @keyword
                ORDER BY p.Id DESC";

            SqlParameter[] parameters = { new SqlParameter("@keyword", "%" + keyword + "%") };
            DataTable dt = DBConnection.GetDataTable(sql, parameters);

            return ConvertToProductList(dt);
        }

        public bool AddProduct(Product product)
        {
            using (SqlConnection conn = DBConnection.GetDBConnection())
            {
                conn.Open();

                // Lệnh INSERT dùng OUTPUT INSERTED.Id để lấy ngay ID vừa sinh ra
                string sqlInsert = @"
            INSERT INTO Product (SKU, Name, CategoryId, Description, BasePrice, ImagePath, IsActive) 
            OUTPUT INSERTED.Id
            VALUES (@sku, @name, @categoryId, @desc, @basePrice, @imagePath, @isActive)";

                int newProductId = 0;
                using (SqlCommand cmd = new SqlCommand(sqlInsert, conn))
                {
                    // Tạo SKU tạm để né lỗi NOT NULL của SQL
                    cmd.Parameters.AddWithValue("@sku", "TEMP-" + Guid.NewGuid().ToString().Substring(0, 8));
                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@categoryId", product.CategoryId);
                    cmd.Parameters.AddWithValue("@desc", (object)product.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@basePrice", product.BasePrice);
                    cmd.Parameters.AddWithValue("@imagePath", (object)product.ImagePath ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@isActive", product.IsActive ?? true);

                    var result = cmd.ExecuteScalar();
                    if (result != null) newProductId = Convert.ToInt32(result);
                }

                // Sau khi có ID thật, tạo SKU Gốc chuẩn và Update lại
                if (newProductId > 0)
                {
                    // 👉 Gọi hàm sinh SKU Gốc (VD: AO-ADIDAS-0001)
                    string finalSKU = GenerateBaseSKU(product.Name, newProductId);

                    string sqlUpdate = "UPDATE Product SET SKU = @finalSKU WHERE Id = @id";
                    using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@finalSKU", finalSKU);
                        cmdUpdate.Parameters.AddWithValue("@id", newProductId);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    // Gán lại cho object để luồng Thêm Biến Thể xài ké
                    product.Id = newProductId;
                    product.SKU = finalSKU;
                    return true;
                }
                return false;
            }
        }
        public bool UpdateProduct(Product product)
        {
            string sql = @"
                UPDATE Product 
                SET SKU = @sku, 
                    Name = @name, 
                    CategoryId = @categoryId, 
                    Description = @desc,
                    BasePrice = @basePrice, 
                    ImagePath = @imagePath,
                    IsActive = @isActive,
                    UpdatedAt = GETDATE()
                WHERE Id = @id";

            SqlParameter[] parameters =
            {
                new SqlParameter("@id", product.Id),
                new SqlParameter("@sku", (object)product.SKU ?? DBNull.Value),
                new SqlParameter("@name", product.Name),
                new SqlParameter("@categoryId", product.CategoryId),
                new SqlParameter("@desc", (object)product.Description ?? DBNull.Value),
                new SqlParameter("@basePrice", product.BasePrice),
                new SqlParameter("@imagePath", (object)product.ImagePath ?? DBNull.Value),
                new SqlParameter("@isActive", product.IsActive ?? true)
            };

            int result = DBConnection.ExecuteNonQuery(sql, parameters);
            return result > 0;
        }

        public bool DeleteProduct(int productId)
        {
            using (SqlConnection conn = DBConnection.GetDBConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlDeleteVariant = "DELETE FROM ProductVariant WHERE ProductId = @productId";
                        using (var cmdVariant = new SqlCommand(sqlDeleteVariant, conn, trans))
                        {
                            cmdVariant.Parameters.Add(new SqlParameter("@productId", productId));
                            cmdVariant.ExecuteNonQuery();
                        }

                        string sqlDeleteProduct = "DELETE FROM Product WHERE Id = @productId";
                        using (var cmdProduct = new SqlCommand(sqlDeleteProduct, conn, trans))
                        {
                            cmdProduct.Parameters.Add(new SqlParameter("@productId", productId));
                            cmdProduct.ExecuteNonQuery();
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

        public List<Product> FilterProducts(int? categoryId, decimal? maxPrice)
        {
            string sql = @"
                SELECT p.Id, p.SKU, p.Name, p.CategoryId, c.CategoryName, 
                       p.Description, p.BasePrice, p.ImagePath, p.IsActive
                FROM Product p
                LEFT JOIN Category c ON p.CategoryId = c.Id
                WHERE (@categoryId IS NULL OR p.CategoryId = @categoryId)
                  AND (@maxPrice IS NULL OR p.BasePrice <= @maxPrice)
                ORDER BY p.BasePrice ASC";

            SqlParameter[] parameters = {
                new SqlParameter("@categoryId", (object)categoryId ?? DBNull.Value),
                new SqlParameter("@maxPrice", (object)maxPrice ?? DBNull.Value)
            };

            DataTable dt = DBConnection.GetDataTable(sql, parameters);
            return ConvertToProductList(dt);
        }

        // ==========================================
        // 2. BIẾN THỂ SẢN PHẨM (PRODUCT VARIANT) & KHO
        // ==========================================

        public List<ProductVariant> GetAllProductVariants()
        {
            try
            {
                string sql = @"
                    SELECT pv.Id, pv.SKU, pv.ProductId, p.Name AS ProductName, 
                           pv.SizeId, s.Name AS SizeName, 
                           pv.ColorId, c.Name AS ColorName, 
                           pv.Quantity, pv.CostPrice, pv.SellingPrice, pv.IsActive
                    FROM ProductVariant pv
                    LEFT JOIN Product p ON pv.ProductId = p.Id
                    LEFT JOIN Size s ON pv.SizeId = s.Id
                    LEFT JOIN Color c ON pv.ColorId = c.Id
                    ORDER BY pv.Id DESC";

                DataTable dt = DBConnection.GetDataTable(sql);
                return ConvertToVariantList(dt);
            }
            catch
            {
                return new List<ProductVariant>();
            }
        }

        public List<ProductVariant> GetVariantsByProductId(int productId)
        {
            try
            {
                string sql = @"
                    SELECT pv.Id, pv.SKU, pv.ProductId, p.Name AS ProductName, 
                           pv.SizeId, s.Name AS SizeName, 
                           pv.ColorId, c.Name AS ColorName, 
                           pv.Quantity, pv.CostPrice, pv.SellingPrice, pv.IsActive
                    FROM ProductVariant pv
                    LEFT JOIN Product p ON pv.ProductId = p.Id
                    LEFT JOIN Size s ON pv.SizeId = s.Id
                    LEFT JOIN Color c ON pv.ColorId = c.Id
                    WHERE pv.ProductId = @productId";

                SqlParameter[] parameters = { new SqlParameter("@productId", productId) };
                DataTable dt = DBConnection.GetDataTable(sql, parameters);
                return ConvertToVariantList(dt);
            }
            catch
            {
                return new List<ProductVariant>();
            }
        }

        public List<ProductVariant> SearchVariants(string keyword)
        {
            try
            {
                string sql = @"
                    SELECT pv.Id, pv.SKU, pv.ProductId, p.Name AS ProductName, 
                           pv.SizeId, s.Name AS SizeName, 
                           pv.ColorId, c.Name AS ColorName, 
                           pv.Quantity, pv.CostPrice, pv.SellingPrice, pv.IsActive
                    FROM ProductVariant pv
                    LEFT JOIN Product p ON pv.ProductId = p.Id
                    LEFT JOIN Size s ON pv.SizeId = s.Id
                    LEFT JOIN Color c ON pv.ColorId = c.Id
                    WHERE p.Name LIKE @key OR pv.SKU LIKE @key OR s.Name LIKE @key OR c.Name LIKE @key
                    ORDER BY pv.Id DESC";

                SqlParameter[] parameters = { new SqlParameter("@key", "%" + keyword + "%") };
                DataTable dt = DBConnection.GetDataTable(sql, parameters);
                return ConvertToVariantList(dt);
            }
            catch
            {
                return new List<ProductVariant>();
            }
        }

        public bool AddProductVariant(ProductVariant variant)
        {
            // Lấy thông tin thật từ DB
            string baseSKU = GetProductSKU(variant.ProductId);
            string colorName = GetColorName(variant.ColorId);
            string sizeName = GetSizeName(variant.SizeId);

            // 👉 Gọi hàm sinh SKU Biến thể (VD: AO-ADIDAS-0001-DEN-S)
            variant.SKU = GenerateVariantSKU(baseSKU, colorName, sizeName);

            string sql = @"
        INSERT INTO ProductVariant 
        (SKU, ProductId, SizeId, ColorId, Quantity, CostPrice, SellingPrice, IsActive) 
        VALUES 
        (@sku, @productId, @sizeId, @colorId, @quantity, @costPrice, @sellingPrice, @isActive)";

            SqlParameter[] parameters =
            {
        new SqlParameter("@sku", variant.SKU),
        new SqlParameter("@productId", variant.ProductId),
        new SqlParameter("@sizeId", variant.SizeId),
        new SqlParameter("@colorId", variant.ColorId),
        new SqlParameter("@quantity", variant.Quantity),
        new SqlParameter("@costPrice", (object)variant.CostPrice ?? DBNull.Value),
        new SqlParameter("@sellingPrice", variant.SellingPrice),
        new SqlParameter("@isActive", variant.IsActive ?? true)
    };

            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool UpdateVariant(ProductVariant variant)
        {
            string sql = @"
                UPDATE ProductVariant 
                SET SKU = @sku,
                    SizeId = @sizeId, 
                    ColorId = @colorId, 
                    Quantity = @quantity,
                    CostPrice = @costPrice,
                    SellingPrice = @sellingPrice,
                    IsActive = @isActive
                WHERE Id = @id";

            SqlParameter[] parameters =
            {
                new SqlParameter("@id", variant.Id),
                new SqlParameter("@sku", (object)variant.SKU ?? DBNull.Value),
                new SqlParameter("@sizeId", variant.SizeId),
                new SqlParameter("@colorId", variant.ColorId),
                new SqlParameter("@quantity", variant.Quantity),
                new SqlParameter("@costPrice", (object)variant.CostPrice ?? DBNull.Value),
                new SqlParameter("@sellingPrice", variant.SellingPrice),
                new SqlParameter("@isActive", variant.IsActive ?? true)
            };

            int result = DBConnection.ExecuteNonQuery(sql, parameters);
            return result > 0;
        }

        public bool UpdateStock(int variantId, int newQuantity)
        {
            using (SqlConnection conn = DBConnection.GetDBConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        int oldQuantity = 0;
                        string sqlGetOld = "SELECT Quantity FROM ProductVariant WHERE Id = @vid";
                        using (var cmdOld = new SqlCommand(sqlGetOld, conn, trans))
                        {
                            cmdOld.Parameters.Add(new SqlParameter("@vid", variantId));
                            oldQuantity = Convert.ToInt32(cmdOld.ExecuteScalar());
                        }

                        int changeAmount = newQuantity - oldQuantity;

                        string sqlUpdate = "UPDATE ProductVariant SET Quantity = @qty WHERE Id = @vid";
                        using (var cmdUpdate = new SqlCommand(sqlUpdate, conn, trans))
                        {
                            cmdUpdate.Parameters.Add(new SqlParameter("@qty", newQuantity));
                            cmdUpdate.Parameters.Add(new SqlParameter("@vid", variantId));
                            cmdUpdate.ExecuteNonQuery();
                        }

                        if (changeAmount != 0)
                        {
                            string type = changeAmount > 0 ? "MANUAL_ADD" : "MANUAL_SUB";
                            string sqlLog = @"
                                INSERT INTO InventoryLog (ProductVariantId, ChangeAmount, Type, UserId, Notes) 
                                VALUES (@vid, @change, @type, @uid, N'Điều chỉnh kho thủ công')";

                            using (var cmdLog = new SqlCommand(sqlLog, conn, trans))
                            {
                                cmdLog.Parameters.Add(new SqlParameter("@vid", variantId));
                                cmdLog.Parameters.Add(new SqlParameter("@change", changeAmount));
                                cmdLog.Parameters.Add(new SqlParameter("@type", type));
                                cmdLog.Parameters.Add(new SqlParameter("@uid", (object)UserSession.CurrentUser?.Id ?? DBNull.Value));
                                cmdLog.ExecuteNonQuery();
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

        public bool DeleteVariant(int variantId)
        {
            try
            {
                string sql = "DELETE FROM ProductVariant WHERE Id = @id";
                SqlParameter[] parameters = { new SqlParameter("@id", variantId) };
                int result = DBConnection.ExecuteNonQuery(sql, parameters);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }


        // ==========================================
        // 3. CÁC HÀM TIỆN ÍCH COMBOBOX & CONVERT
        // ==========================================

        private List<Product> ConvertToProductList(DataTable dt)
        {
            List<Product> list = new List<Product>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Product
                {
                    Id = Convert.ToInt32(row["Id"]),
                    SKU = row["SKU"] == DBNull.Value ? "" : row["SKU"].ToString(),
                    Name = row["Name"].ToString(),
                    CategoryId = Convert.ToInt32(row["CategoryId"]),
                    CategoryName = row["CategoryName"] == DBNull.Value ? "" : row["CategoryName"].ToString(),
                    Description = row["Description"] == DBNull.Value ? "" : row["Description"].ToString(),
                    BasePrice = Convert.ToDecimal(row["BasePrice"]),
                    ImagePath = row["ImagePath"] == DBNull.Value ? null : row["ImagePath"].ToString(),
                    IsActive = row["IsActive"] == DBNull.Value ? true : Convert.ToBoolean(row["IsActive"])
                });
            }
            return list;
        }

        private List<ProductVariant> ConvertToVariantList(DataTable dt)
        {
            List<ProductVariant> variants = new List<ProductVariant>();
            foreach (DataRow row in dt.Rows)
            {
                variants.Add(new ProductVariant
                {
                    Id = Convert.ToInt32(row["Id"]),
                    SKU = row["SKU"] == DBNull.Value ? "" : row["SKU"].ToString(),
                    ProductId = Convert.ToInt32(row["ProductId"]),
                    ProductName = row.Table.Columns.Contains("ProductName") && row["ProductName"] != DBNull.Value ? row["ProductName"].ToString() : "",
                    SizeId = Convert.ToInt32(row["SizeId"]),
                    SizeName = row["SizeName"] == DBNull.Value ? "" : row["SizeName"].ToString(),
                    ColorId = Convert.ToInt32(row["ColorId"]),
                    ColorName = row["ColorName"] == DBNull.Value ? "" : row["ColorName"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    CostPrice = row["CostPrice"] == DBNull.Value ? 0m : Convert.ToDecimal(row["CostPrice"]),
                    SellingPrice = Convert.ToDecimal(row["SellingPrice"]),
                    IsActive = row["IsActive"] == DBNull.Value ? true : Convert.ToBoolean(row["IsActive"])
                });
            }
            return variants;
        }

        public DataTable GetAllSizes()
        {
            string sql = "SELECT Id, Name FROM Size WHERE IsActive = 1";
            return DBConnection.GetDataTable(sql);
        }

        public DataTable GetAllColors()
        {
            string sql = "SELECT Id, Name FROM Color WHERE IsActive = 1";
            return DBConnection.GetDataTable(sql);
        }

        public DataTable GetAllCategories()
        {
            string sql = "SELECT Id, CategoryName FROM Category WHERE IsActive = 1";
            return DBConnection.GetDataTable(sql);
        }

        // ==========================================
        // 4. CÁC HÀM GENERATE TÊN VÀ MÃ SKU
        // ==========================================

        // ==========================================
        // CỤM HÀM TẠO MÃ SKU KHÔNG DẤU
        // ==========================================

        public string GenerateBaseSKU(string productName, int productId)
        {
            string nameCode = RemoveSignAndFormat(productName);
            return $"{nameCode}-{productId:D4}"; // VD: AO-ADIDAS-0001
        }

        public string GenerateVariantSKU(string baseSKU, string colorName, string sizeName)
        {
            string colorCode = RemoveSignAndFormat(colorName);
            string sizeCode = RemoveSignAndFormat(sizeName);
            return $"{baseSKU}-{colorCode}-{sizeCode}"; // VD: AO-ADIDAS-0001-DEN-S
        }
        // Hàm thần thánh: Chuyển "Áo Adidas" -> "AO-ADIDAS", "Đen" -> "DEN", "Trắng" -> "TRANG"
        public string RemoveSignAndFormat(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return "NA";

            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = text.Normalize(System.Text.NormalizationForm.FormD);
            string result = regex.Replace(temp, string.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');

            result = new string(result.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray());
            return string.Join("-", result.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).ToUpper();
        }
        private string GetProductSKU(int productId)
        {
            try
            {
                string sql = "SELECT SKU FROM Product WHERE Id = @id";
                var dt = DBConnection.GetDataTable(sql, new[] { new SqlParameter("@id", productId) });
                return dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : "UNKNOWN";
            }
            catch { return "UNKNOWN"; }
        }

        // --- Các hàm truy xuất Database để lấy tên ---
        private string GetProductName(int id)
        {
            try
            {
                string sql = "SELECT Name FROM Product WHERE Id = @id";
                var p = new SqlParameter("@id", id);
                var dt = DBConnection.GetDataTable(sql, new[] { p });
                return dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : "";
            }
            catch { return ""; }
        }

        private string GetColorName(int id)
        {
            try
            {
                string sql = "SELECT Name FROM Color WHERE Id = @id";
                var p = new SqlParameter("@id", id);
                var dt = DBConnection.GetDataTable(sql, new[] { p });
                return dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : "";
            }
            catch { return ""; }
        }

        private string GetSizeName(int id)
        {
            try
            {
                string sql = "SELECT Name FROM Size WHERE Id = @id";
                var p = new SqlParameter("@id", id);
                var dt = DBConnection.GetDataTable(sql, new[] { p });
                return dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : "";
            }
            catch { return ""; }
        }
    }
}