using System.Collections.Generic;
using System.Data;
using CuaHangDienThoaiAPI.Models;
using CuaHangDienThoaiAPI.Utils;
using Microsoft.Data.SqlClient;

namespace CuaHangDienThoaiAPI.DAL
{
    public class OrderDAL
    {
        public int addOrder(Order order)
        {
            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@Name", order.NameCustomer),
                new SqlParameter("@Phone", order.PhoneNumber),
                new SqlParameter("@Address", order.Address)
            };
            return DBHelper.NonQuery("addOrder", parameters);
        }

        public int updateOrder(int ID, int Status)
        {
            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@ID", ID),
                new SqlParameter("@Status", Status),
            };
            return DBHelper.NonQuery("updateOrder", parameters);
        }

        public List<Order> getOrderList()
        {
            DataTable dataTable = DBHelper.Query("getOrder", null);
            List<Order> orders = new List<Order>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Order order = new Order()
                {
                    Address = dr["Address"].ToString(),
                    ID = int.Parse(dr["ID"].ToString()),
                    NameCustomer = dr["NameCustomer"].ToString(),
                    PhoneNumber = dr["PhoneNumber"].ToString()
                };
                orders.Add(order);
            }

            return orders;
        }
        
    }
}