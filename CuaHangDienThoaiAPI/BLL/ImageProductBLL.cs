using System.Collections.Generic;
using CuaHangDienThoaiAPI.DAL;
using CuaHangDienThoaiAPI.Models;

namespace CuaHangDienThoaiAPI.BLL
{
    public class ImageProductBLL
    {
        private ImageProductDAL dal = new ImageProductDAL();

        public int AddImage(ImageProduct imageProduct)
        {
            return dal.addImageProduct(imageProduct);
        }

        public int UpdateImage(int id, ImageProduct imageProduct)
        {
            return dal.updateImageProduct(id, imageProduct);
        }

        public int DeleteImage(int id)
        {
            return dal.deleteImageProduct(id);
        }

        public List<ImageProduct> GetListImage(int idProduct)
        {
            return dal.getImageProduct(idProduct);
        }

        public ImageProduct GetImage(int id)
        {
            return dal.GetImageProduct(id);
        }
    }
}