namespace DATN_STMDT_THELIEMS.Models
{
    public class Order_details
    {
        public int Id { get; set; }
        public int? Order_id { get; set; }
        public Orders? Orders { get; set; }
        public int? Product_variant_id { get; set; }
        public Product_variants? Product_variants { get; set; }
        public int Product_price { get; set; } 
        public int Product_quantity { get; set; }
        public ICollection<Product_review>? Product_Reviews { get; set; }

		public int TotalPrice => Product_price * Product_quantity;
	}
}
