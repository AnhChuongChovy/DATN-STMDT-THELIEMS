namespace DATN_STMDT_THELIEMS.Models
{
    public class Product_variants
    {
        public int Id { get; set; }
        public int Product_id { get; set; }
        public Products Products { get; set; }
        public string Sku { get; set; } 
        public int Quantity { get; set; }
        public string Image { get; set; } 
        public decimal Price { get; set; }
        public ICollection<Product_variant_option> Product_Variant_Options { get; set; }
        public ICollection<Product_Image> Product_Images { get; set; }
        public ICollection<Order_details> Order_Details { get; set; }


    }
}
