using System.Collections.Generic;
using System.Data;
using CuaHangDienThoaiAPI.Models;
using CuaHangDienThoaiAPI.Utils;
using Microsoft.Data.SqlClient;

namespace CuaHangDienThoaiAPI.DAL
{
    public class CategoryDAL
    {
        public int addCategory(Category category)
        {
            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@Name", category.Name),
                new SqlParameter("@Image", category.Image)
            };
            return DBHelper.NonQuery("addCategory", parameters);
        }

        public int updateCategory(int ID, Category category)
        {
            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@ID", ID),
                new SqlParameter("@Name", category.Name),
                new SqlParameter("@Image", category.Image)
            };
            return DBHelper.NonQuery("updateCategory", parameters);
        }

        public int deleteCategory(int ID)
        {
            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@ID", ID)
            };
            return DBHelper.NonQuery("deleteCategory", parameters);
        }

        public List<Category> getCategoryList()
        {
            List<Category> categories = new List<Category>();
            DataTable dataTable = DBHelper.Query("getAllCategory", null);
            foreach (DataRow dr in dataTable.Rows)
            {
                Category category = new Category()
                {
                    ID = int.Parse(dr["ID"].ToString()),
                    Image = dr["Image"].ToString(),
                    Name = dr["Name"].ToString()
                };
                categories.Add(category);
            }

            return categories;
        }

        public Category getCategoryByID(int ID)
        {
            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@ID", ID)
            };
            Category category = null;
            DataTable dataTable = DBHelper.Query("getCategoryByID", parameters);
            foreach (DataRow dr in dataTable.Rows)
            {
                category = new Category()
                {
                    ID = int.Parse(dr["ID"].ToString()),
                    Image = dr["Image"].ToString(),
                    Name = dr["Name"].ToString()
                };
            }

            return category;
        }
    }
}