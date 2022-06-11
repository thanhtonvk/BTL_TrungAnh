using System.Collections.Generic;
using System.Linq;
using CuaHangDienThoaiAPI.DAL;
using CuaHangDienThoaiAPI.Models;

namespace CuaHangDienThoaiAPI.BLL
{
    public class OrderBLL
    {
        private OrderDAL dal = new OrderDAL();

        public int AddOrder(Order order)
        {
            return dal.addOrder(order);
        }

        public int UpdateOrder(int id, int status)
        {
            return dal.updateOrder(id, status);
        }

        public List<Order> GetOrderList(string keyword)
        {
            var list = dal.getOrderList();
            if (string.IsNullOrEmpty(keyword))
            {
                return list;
            }

            return list.Where(x =>
                    x.NameCustomer.Contains(keyword) || x.Address.Contains(keyword) || x.PhoneNumber.Contains(keyword))
                .ToList();
        }
        
    }
}