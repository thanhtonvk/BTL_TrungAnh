using CuaHangDienThoaiAPI.DAL;
using CuaHangDienThoaiAPI.Models;

namespace CuaHangDienThoaiAPI.BLL
{
    public class AccountBLL
    {
        private AccountDAL dal = new AccountDAL();

        public int Register(string username, string password)
        {
            return dal.Register(username, password);
        }

        public Account Login(string username, string password)
        {
            return dal.Login(username, password);
        }
    }
}