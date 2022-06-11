using CuaHangDienThoaiAPI.BLL;
using Microsoft.AspNetCore.Mvc;

namespace CuaHangDienThoaiAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private OrderDetailsBLL _bll = new OrderDetailsBLL();

        [HttpPost]
        public IActionResult Add(int orderID, int productID, int quantity)
        {
            return Ok(_bll.AddOrderDetails(orderID, productID, quantity));
        }

        [HttpGet]
        public IActionResult Get(int orderID)
        {
            return Ok(_bll.GetOrderDetailsList(orderID));
        }
    }
}