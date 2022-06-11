namespace CuaHangDienThoaiAPI.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string NameCustomer { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
    }
}