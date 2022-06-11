using CuaHangDienThoaiAPI.BLL;
using CuaHangDienThoaiAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuaHangDienThoaiAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategoryBLL _bll = new CategoryBLL();

        [HttpPost]
        public IActionResult PostCategory(Category category)
        {
            if (_bll.AddCategory(category) >= 0) return Ok("Thành công");
            return BadRequest("Lỗi");
        }

        [HttpPut]
        public IActionResult PutCategory(Category category)
        {
            if (_bll.UpdateCategory(category.ID, category) >= 0) return Ok("Thành công");
            return BadRequest("Lỗi");
        }

        [HttpPut]
        public IActionResult DeleteCategory(int id)
        {
            if (_bll.DeleteCategory(id) >=0) return Ok("Thành công");
            return BadRequest("Lỗi");
        }

        [HttpGet]
        public IActionResult GetCategoryList(string keyword)
        {
            if (keyword.Equals("null")) return Ok(_bll.GetListCategory(""));
            return Ok(_bll.GetListCategory(keyword));
        }

        [HttpGet]
        public IActionResult GetCategory(int id)
        {
            return Ok(_bll.GetCategory(id));
        }
    }
}