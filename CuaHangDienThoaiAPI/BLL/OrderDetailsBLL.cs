using System.Collections.Generic;
using CuaHangDienThoaiAPI.DAL;
using CuaHangDienThoaiAPI.Models;

namespace CuaHangDienThoaiAPI.BLL
{
    public class OrderDetailsBLL
    {
        private OrderDetailsDAL _dal = new OrderDetailsDAL();

        public int AddOrderDetails(int orderID, int productID, int quantity)
        {
            return _dal.addOrderDetails(orderID, productID, quantity);
        }

        public List<OrderDetails> GetOrderDetailsList(int orderID)
        {
            return _dal.getOrderDetails(orderID);
        }
        
    }
}