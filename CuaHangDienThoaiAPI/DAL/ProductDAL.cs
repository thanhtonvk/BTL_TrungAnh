using System.Collections.Generic;
using System.Data;
using CuaHangDienThoaiAPI.Models;
using CuaHangDienThoaiAPI.Utils;
using Microsoft.Data.SqlClient;

namespace CuaHangDienThoaiAPI.DAL
{
    public class ProductDAL
    {
        public int AddProduct(Product product)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", product.Name),
                new SqlParameter("@CategoryID", product.IDCategory),
                new SqlParameter("@Image", product.Image),
                new SqlParameter("@Details", product.Details),
                new SqlParameter("@Description", product.Description),
                new SqlParameter("@Cost", product.Cost),
                new SqlParameter("@IsHot", product.IsHot),
                new SqlParameter("@IsSale", product.IsSale)
            };
            return DBHelper.NonQuery("addProduct", parameters);
        }

        public int UpdateProduct(int ID, Product product)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", ID),
                new SqlParameter("@Name", product.Name),
                new SqlParameter("@CategoryID", product.IDCategory),
                new SqlParameter("@Image", product.Image),
                new SqlParameter("@Details", product.Details),
                new SqlParameter("@Description", product.Description),
                new SqlParameter("@Cost", product.Cost),
                new SqlParameter("@IsHot", product.IsHot),
                new SqlParameter("@IsSale", product.IsSale)
            };
            return DBHelper.NonQuery("updateProduct", parameters);
        }

        public int DeleteProduct(int ID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("id", ID)
            };
            return DBHelper.NonQuery("deleteProduct", parameters);
        }

        public List<Product> getAllProduct()
        {
            DataTable dataTable = DBHelper.Query("getAllProduct", null);
            List<Product> productList = new List<Product>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Product product = new Product()
                {
                    ID = int.Parse(dr["ID"].ToString()),
                    Name = dr["Name"].ToString(),
                    Category = dr["CategoryName"].ToString(),
                    Image = dr["Image"].ToString(),
                    Details = dr["Details"].ToString(),
                    Description = dr["Description"].ToString(),
                    Cost = int.Parse(dr["Cost"].ToString()),
                };
                productList.Add(product);
            }

            return productList;
        }

        public List<Product> getProductByIDCategory(int IDCategory)
        {
            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@idCategory", IDCategory)
            };
            DataTable dataTable = DBHelper.Query("getProductByCategory", parameters);
            List<Product> productList = new List<Product>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Product product = new Product()
                {
                    ID = int.Parse(dr["ID"].ToString()),
                    Name = dr["Name"].ToString(),
                    Category = dr["CategoryName"].ToString(),
                    Image = dr["Image"].ToString(),
                    Details = dr["Details"].ToString(),
                    Description = dr["Description"].ToString(),
                    Cost = int.Parse(dr["Cost"].ToString()),
                   
                };
                productList.Add(product);
            }

            return productList;
        }

        public List<Product> getProductHot()
        {
            DataTable dataTable = DBHelper.Query("getProductHot", null);
            List<Product> productList = new List<Product>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Product product = new Product()
                {
                    ID = int.Parse(dr["ID"].ToString()),
                    Name = dr["Name"].ToString(),
                    Category = dr["CategoryName"].ToString(),
                    Image = dr["Image"].ToString(),
                    Details = dr["Details"].ToString(),
                    Description = dr["Description"].ToString(),
                    Cost = int.Parse(dr["Cost"].ToString()),
                };
                productList.Add(product);
            }

            return productList;
        }

        public List<Product> getProductSale()
        {
            DataTable dataTable = DBHelper.Query("getProductSale", null);
            List<Product> productList = new List<Product>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Product product = new Product()
                {
                    ID = int.Parse(dr["ID"].ToString()),
                    Name = dr["Name"].ToString(),
                    Category = dr["CategoryName"].ToString(),
                    Image = dr["Image"].ToString(),
                    Details = dr["Details"].ToString(),
                    Description = dr["Description"].ToString(),
                    Cost = int.Parse(dr["Cost"].ToString()),
                  
                };
                productList.Add(product);
            }

            return productList;
        }

        public Product getProductByID(int id)
        {
            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@ID", id)
            };
            DataTable dataTable = DBHelper.Query("getProductById", parameters);
            Product product = null;
            foreach (DataRow dr in dataTable.Rows)
            {
                product = new Product()
                {
                    ID = int.Parse(dr["ID"].ToString()),
                    Name = dr["Name"].ToString(),
                    Category = dr["CategoryName"].ToString(),
                    Image = dr["Image"].ToString(),
                    Details = dr["Details"].ToString(),
                    Description = dr["Description"].ToString(),
                    Cost = int.Parse(dr["Cost"].ToString()),
                    
                };
            }

            return product;
        }
    }
}