namespace DATN_STMDT_THELIEMS.Models
{
    public class Product_variants
    {
        public int Id { get; set; }
        public int Product_id { get; set; }
        public string Sku { get; set; } 
        public int Quantity { get; set; }
        public string Image { get; set; } 
        public decimal Price { get; set; }
    }
}
