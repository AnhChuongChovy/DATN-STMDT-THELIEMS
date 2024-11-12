namespace DATN_STMDT_THELIEMS.Models
{
    public class Checkout
    {
        public Products Product { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Image {  get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
