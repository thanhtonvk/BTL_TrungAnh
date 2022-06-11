using CuaHangDienThoaiAPI.BLL;
using CuaHangDienThoaiAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuaHangDienThoaiAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductBLL _bll = new ProductBLL();

        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            return Ok(_bll.AddProduct(product));
        }

        [HttpPut]
        public IActionResult PutProduct(Product product)
        {
           return Ok(_bll.UpdateProduct(product.ID, product) > 0);
           
        }

        [HttpPut]
        public IActionResult DeleteProduct(int id)
        {
            if (_bll.DeleteProduct(id) > 0) return Ok("Success");
            return BadRequest("Error");
        }

        [HttpGet]
        public IActionResult GetProductList(string keyword)
        {
            if (keyword == "null") return Ok(_bll.GetListProduct(""));
            return Ok(_bll.GetListProduct(keyword));
        }

        [HttpGet]
        public IActionResult GetProductByCategory(int idCategory)
        {
            return Ok(_bll.GetProductByCategory(idCategory));
        }

        [HttpGet]
        public IActionResult GetProductIsSale()
        {
            return Ok(_bll.GetProductIsSale());
        }

        [HttpGet]
        public IActionResult GetProductIsHot()
        {
            return Ok(_bll.GetProductIsHot());
        }

        [HttpGet]
        public IActionResult GetProductById(int id)
        {
            return Ok(_bll.GetProductById(id));
        }
    }
}