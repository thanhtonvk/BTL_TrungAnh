using System;
using System.Collections.Generic;
using System.Data;
using CuaHangDienThoaiAPI.Models;
using CuaHangDienThoaiAPI.Utils;
using Microsoft.Data.SqlClient;

namespace CuaHangDienThoaiAPI.DAL
{
    public class ImageProductDAL
    {
        public int addImageProduct(ImageProduct imageProduct)
        {
            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@ProductID", imageProduct.ProductID),
                new SqlParameter("@Image", imageProduct.Image)
            };
            return DBHelper.NonQuery("addImageProduct", parameters);
        }

        public int updateImageProduct(int ID, ImageProduct imageProduct)
        {
            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@ID", ID),
                new SqlParameter("@ProductID", imageProduct.ProductID),
                new SqlParameter("@Image", imageProduct.Image)
            };
            return DBHelper.NonQuery("updateImageProduct", parameters);
        }

        public int deleteImageProduct(int ID)
        {
            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@ID", ID)
            };
            return DBHelper.NonQuery("deleteImageProduct", parameters);
        }

        public ImageProduct GetImageProduct(int ID)
        {
            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@ID", ID)
            };
            DataTable dataTable = DBHelper.Query("getImageProductByID", parameters);
            ImageProduct imageProduct = null;
            foreach (DataRow dr in dataTable.Rows)
            {
                imageProduct = new ImageProduct()
                {
                    ID =(int) dr[0],
                    ProductID = (int) dr[1],
                    Image = dr[2].ToString()!,
                   
                };
            }

            return imageProduct;
        }

        public List<ImageProduct> getImageProduct(int IDProduct)
        {
            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@ProductID", IDProduct)
            };
            List<ImageProduct> imageProducts = new List<ImageProduct>();
            DataTable dataTable = DBHelper.Query("getImageProduct", parameters);
            foreach (DataRow dr in dataTable.Rows)
            {
                ImageProduct imageProduct = new ImageProduct();
                imageProduct = new ImageProduct()
                {
                    ID =(int) dr[0],
                    ProductID = (int) dr[1],
                    Image = dr[2].ToString()!,
                   
                };

                imageProducts.Add(imageProduct);
                Console.Write(dr[0].ToString());
            }

            return imageProducts;
        }
    }
}