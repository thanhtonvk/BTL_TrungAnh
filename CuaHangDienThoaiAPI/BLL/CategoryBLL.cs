using System.Collections.Generic;
using System.Linq;
using CuaHangDienThoaiAPI.DAL;
using CuaHangDienThoaiAPI.Models;

namespace CuaHangDienThoaiAPI.BLL
{
    public class CategoryBLL
    {
        private CategoryDAL dal = new CategoryDAL();

        public List<Category> GetListCategory(string keyword)
        {
            var list = dal.getCategoryList();
            if (string.IsNullOrEmpty(keyword)) return list;
            return list.Where(x => x.Name.ToLower().Contains(keyword.ToLower())).ToList();
        }

        public int AddCategory(Category category)
        {
            return dal.addCategory(category);
        }

        public int UpdateCategory(int id, Category category)
        {
            return dal.updateCategory(id, category);
        }

        public int DeleteCategory(int id)
        {
            return dal.deleteCategory(id);
        }

        public Category GetCategory(int id)
        {
            return dal.getCategoryByID(id);
        }
    }
}