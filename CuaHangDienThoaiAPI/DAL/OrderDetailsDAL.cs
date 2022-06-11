using System.Collections.Generic;
using System.Data;
using CuaHangDienThoaiAPI.Models;
using CuaHangDienThoaiAPI.Utils;
using Microsoft.Data.SqlClient;

namespace CuaHangDienThoaiAPI.DAL
{
    public class OrderDetailsDAL
    {
        public int addOrderDetails(int OrderID, int ProductID, int Quantity)
        {
            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@OrderID", OrderID),
                new SqlParameter("@ProductID", ProductID),
                new SqlParameter("@Quantity", Quantity)
            };
            return DBHelper.NonQuery("addOrderDetails", parameters);
        }

        public List<OrderDetails> getOrderDetails(int OrderID)
        {
            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@OrderID", OrderID)
            };
            DataTable dataTable = DBHelper.Query("getOrderDetails", parameters);
            List<OrderDetails> orderDetailsList = new List<OrderDetails>();
            foreach (DataRow dr in dataTable.Rows)
            {
                OrderDetails orderDetails = new OrderDetails()
                {
                    Cost = int.Parse(dr["Cost"].ToString()),
                    ProductName = dr["Name"].ToString(),
                    Quantity = int.Parse(dr["Quantity"].ToString()),
                    Sum = int.Parse(dr["Money"].ToString())
                };
                orderDetailsList.Add(orderDetails);
            }

            return orderDetailsList;
        }
        
    }
}