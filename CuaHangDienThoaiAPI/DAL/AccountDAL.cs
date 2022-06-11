using System.Data;
using CuaHangDienThoaiAPI.Models;
using CuaHangDienThoaiAPI.Utils;
using Microsoft.Data.SqlClient;

namespace CuaHangDienThoaiAPI.DAL
{
    public class AccountDAL
    {
        public int Register(string Username, string password)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@username", Username),
                new SqlParameter("@password", password)
            };
            int rs = DBHelper.NonQuery("register", parameters);
            return rs;
        }

        public Account Login(string username, string password)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };
            Account account = null;
            DataTable table = DBHelper.Query("login", parameters);
            foreach (DataRow row in table.Rows)
            {
                account = new Account()
                {
                    UserName = row["UserName"].ToString(),
                    Password = row["Password"].ToString()
                };
            }

            return account;
        }
    }
}