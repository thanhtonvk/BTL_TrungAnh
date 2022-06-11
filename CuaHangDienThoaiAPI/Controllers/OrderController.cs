using CuaHangDienThoaiAPI.BLL;
using CuaHangDienThoaiAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuaHangDienThoaiAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderBLL _bll = new OrderBLL();

        [HttpPost]
        public IActionResult Add(Order order)
        {
            return Ok(_bll.AddOrder(order));
        }

        [HttpPut]
        public IActionResult Update(int id, int status)
        {
            return Ok(_bll.UpdateOrder(id, status));
        }

        [HttpGet]
        public IActionResult Get(string keyword)
        {
            return Ok(_bll.GetOrderList(keyword));
        }
    }
}