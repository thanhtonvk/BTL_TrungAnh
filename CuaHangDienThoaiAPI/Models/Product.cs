namespace CuaHangDienThoaiAPI.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int IDCategory { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public string Details { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public int IsHot { get; set; }
        public int IsSale { get; set; }
    }
}