using SportShop.DataBase;
using SportShop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SportShop.Controller
{
    public class QuanLyLoaiSanPhamController
    {
        #region ================= QUẢN LÝ DANH MỤC (CATEGORY) =================

        public List<Category> GetAllCategories()
        {
            const string sql = "SELECT Id, CategoryName, IsActive, CreatedAt FROM Category ORDER BY Id DESC";
            DataTable dt = DBConnection.GetDataTable(sql);
            return ConvertToCategoryList(dt);
        }

        public Category GetCategoryById(int id)
        {
            const string sql = "SELECT Id, CategoryName, IsActive, CreatedAt FROM Category WHERE Id = @id";
            var p = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { p });
            var list = ConvertToCategoryList(dt);

            return list.Count > 0 ? list[0] : null;
        }

        public bool AddCategory(Category category)
        {
            const string sql = "INSERT INTO Category (CategoryName, IsActive) VALUES (@name, @isActive)";
            var parameters = new[]
            {
                new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = category.CategoryName },
                new SqlParameter("@isActive", SqlDbType.Bit) { Value = category.IsActive ?? true }
            };

            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool UpdateCategory(Category category)
        {
            const string sql = "UPDATE Category SET CategoryName = @name, IsActive = @isActive WHERE Id = @id";
            var parameters = new[]
            {
                new SqlParameter("@id", SqlDbType.Int) { Value = category.Id },
                new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = category.CategoryName },
                new SqlParameter("@isActive", SqlDbType.Bit) { Value = category.IsActive ?? true }
            };

            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool DeleteCategory(int id)
        {
            const string sqlCheck = "SELECT COUNT(*) FROM Product WHERE CategoryId = @id";
            var pCheck = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            DataTable dtCheck = DBConnection.GetDataTable(sqlCheck, new[] { pCheck });

            if (dtCheck.Rows.Count > 0 && Convert.ToInt32(dtCheck.Rows[0][0]) > 0)
            {
                return false;
            }

            const string sqlDelete = "DELETE FROM Category WHERE Id = @id";
            var pDelete = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            return DBConnection.ExecuteNonQuery(sqlDelete, new[] { pDelete }) > 0;
        }

        public List<Category> SearchCategories(string keyword)
        {
            const string sql = "SELECT Id, CategoryName, IsActive, CreatedAt FROM Category WHERE CategoryName LIKE @key ORDER BY Id DESC";
            var pKey = new SqlParameter("@key", SqlDbType.NVarChar, 150) { Value = "%" + keyword + "%" };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { pKey });

            return ConvertToCategoryList(dt);
        }

        #endregion


        #region ================= QUẢN LÝ KÍCH CỠ (SIZE) =================

        public List<Size> GetAllSizes()
        {
            const string sql = "SELECT Id, Name, IsActive FROM Size ORDER BY Id DESC";
            DataTable dt = DBConnection.GetDataTable(sql);
            return ConvertToSizeList(dt);
        }

        public Size GetSizeById(int id)
        {
            const string sql = "SELECT Id, Name, IsActive FROM Size WHERE Id = @id";
            var p = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { p });
            var list = ConvertToSizeList(dt);

            return list.Count > 0 ? list[0] : null;
        }

        public bool AddSize(Size size)
        {
            const string sql = "INSERT INTO Size (Name, IsActive) VALUES (@name, @isActive)";
            var parameters = new[]
            {
                new SqlParameter("@name", SqlDbType.NVarChar, 20) { Value = size.Name },
                new SqlParameter("@isActive", SqlDbType.Bit) { Value = size.IsActive ?? true }
            };

            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool UpdateSize(Size size)
        {
            const string sql = "UPDATE Size SET Name = @name, IsActive = @isActive WHERE Id = @id";
            var parameters = new[]
            {
                new SqlParameter("@id", SqlDbType.Int) { Value = size.Id },
                new SqlParameter("@name", SqlDbType.NVarChar, 20) { Value = size.Name },
                new SqlParameter("@isActive", SqlDbType.Bit) { Value = size.IsActive ?? true }
            };

            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool DeleteSize(int id)
        {
            const string sqlCheck = "SELECT COUNT(*) FROM ProductVariant WHERE SizeId = @id";
            var pCheck = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            DataTable dtCheck = DBConnection.GetDataTable(sqlCheck, new[] { pCheck });

            if (dtCheck.Rows.Count > 0 && Convert.ToInt32(dtCheck.Rows[0][0]) > 0)
            {
                return false;
            }

            const string sqlDelete = "DELETE FROM Size WHERE Id = @id";
            var pDelete = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            return DBConnection.ExecuteNonQuery(sqlDelete, new[] { pDelete }) > 0;
        }

        public List<Size> SearchSizes(string keyword)
        {
            const string sql = "SELECT Id, Name, IsActive FROM Size WHERE Name LIKE @key ORDER BY Id DESC";
            var pKey = new SqlParameter("@key", SqlDbType.NVarChar, 50) { Value = "%" + keyword + "%" };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { pKey });

            return ConvertToSizeList(dt);
        }

        #endregion


        #region ================= QUẢN LÝ MÀU SẮC (COLOR) =================

        public List<Color> GetAllColors()
        {
            const string sql = "SELECT Id, Name, IsActive FROM Color ORDER BY Id DESC";
            DataTable dt = DBConnection.GetDataTable(sql);
            return ConvertToColorList(dt);
        }

        public Color GetColorById(int id)
        {
            const string sql = "SELECT Id, Name, IsActive FROM Color WHERE Id = @id";
            var p = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { p });
            var list = ConvertToColorList(dt);

            return list.Count > 0 ? list[0] : null;
        }

        public bool AddColor(Color color)
        {
            const string sql = "INSERT INTO Color (Name, IsActive) VALUES (@name, @isActive)";
            var parameters = new[]
            {
                new SqlParameter("@name", SqlDbType.NVarChar, 50) { Value = color.Name },
                new SqlParameter("@isActive", SqlDbType.Bit) { Value = color.IsActive }
            };

            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool UpdateColor(Color color)
        {
            const string sql = "UPDATE Color SET Name = @name, IsActive = @isActive WHERE Id = @id";
            var parameters = new[]
            {
                new SqlParameter("@id", SqlDbType.Int) { Value = color.Id },
                new SqlParameter("@name", SqlDbType.NVarChar, 50) { Value = color.Name },
                new SqlParameter("@isActive", SqlDbType.Bit) { Value = color.IsActive }
            };

            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool DeleteColor(int id)
        {
            const string sqlCheck = "SELECT COUNT(*) FROM ProductVariant WHERE ColorId = @id";
            var pCheck = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            DataTable dtCheck = DBConnection.GetDataTable(sqlCheck, new[] { pCheck });

            if (dtCheck.Rows.Count > 0 && Convert.ToInt32(dtCheck.Rows[0][0]) > 0)
            {
                return false;
            }

            const string sqlDelete = "DELETE FROM Color WHERE Id = @id";
            var pDelete = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            return DBConnection.ExecuteNonQuery(sqlDelete, new[] { pDelete }) > 0;
        }

        public List<Color> SearchColors(string keyword)
        {
            const string sql = "SELECT Id, Name, IsActive FROM Color WHERE Name LIKE @key ORDER BY Id DESC";
            var pKey = new SqlParameter("@key", SqlDbType.NVarChar, 100) { Value = "%" + keyword + "%" };
            DataTable dt = DBConnection.GetDataTable(sql, new[] { pKey });

            return ConvertToColorList(dt);
        }

        #endregion


        #region ================= CÁC HÀM HELPER CHUYỂN ĐỔI DATATABLE SANG LIST =================

        private List<Category> ConvertToCategoryList(DataTable dt)
        {
            var list = new List<Category>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Category
                {
                    Id = Convert.ToInt32(row["Id"]),
                    CategoryName = row["CategoryName"].ToString(),
                    IsActive = row["IsActive"] == DBNull.Value ? true : Convert.ToBoolean(row["IsActive"]),
                    CreatedAt = row["CreatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["CreatedAt"])
                });
            }
            return list;
        }

        private List<Size> ConvertToSizeList(DataTable dt)
        {
            var list = new List<Size>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Size
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    IsActive = row["IsActive"] == DBNull.Value ? true : Convert.ToBoolean(row["IsActive"])
                });
            }
            return list;
        }

        private List<Color> ConvertToColorList(DataTable dt)
        {
            var list = new List<Color>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Color
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    IsActive = row["IsActive"] == DBNull.Value ? true : Convert.ToBoolean(row["IsActive"])
                });
            }
            return list;
        }

        #endregion
    }
}