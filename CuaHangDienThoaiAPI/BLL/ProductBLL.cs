using System.Collections.Generic;
using System.Linq;
using CuaHangDienThoaiAPI.DAL;
using CuaHangDienThoaiAPI.Models;

namespace CuaHangDienThoaiAPI.BLL
{
    public class ProductBLL
    {
        private ProductDAL _dal = new ProductDAL();

        public int AddProduct(Product product)
        {
            return _dal.AddProduct(product);
        }

        public int UpdateProduct(int id, Product product)
        {
            return _dal.UpdateProduct(id, product);
        }

        public int DeleteProduct(int id)
        {
            return _dal.DeleteProduct(id);
        }

        public List<Product> GetListProduct(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)) return _dal.getAllProduct();
            return _dal.getAllProduct().Where(x =>
                x.Name.Contains(keyword) || x.Details.Contains(keyword) || x.Category.Contains(keyword)).ToList();
        }

        public Product GetProductById(int id)
        {
            return _dal.getProductByID(id);
        }

        public List<Product> GetProductByCategory(int idCategory)
        {
            return _dal.getProductByIDCategory(idCategory);
        }

        public List<Product> GetProductIsHot()
        {
            return _dal.getProductHot();
        }

        public List<Product> GetProductIsSale()
        {
            return _dal.getProductSale();
        }
    }
}