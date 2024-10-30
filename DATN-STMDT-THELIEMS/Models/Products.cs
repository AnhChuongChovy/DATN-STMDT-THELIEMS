
namespace DATN_STMDT_THELIEMS.Models
{
    public class Products
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Categories Categories { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int ShopId { get; set; }
        public Shops Shops { get; set; }
        public int BrandId { get; set; }
        public Brands Brands { get; set; }
        public string ProductLink { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int ViewCount { get; set; }
        public int SoldCount { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeyword { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Product_variants> Product_Variants { get; set; }
        public ICollection<Product_parts> Product_Parts { get; set; }

		public int? Category_id { get; set; }
		public Categories? Categories { get; set; }
		public int? Supplier_id { get; set; }
		public Supplier? Suppliers { get; set; }
		public int? Shop_id { get; set; }
		public Shops? Shops { get; set; }
		public int? Brand_id { get; set; }
		public Brands? Brands { get; set; }
		public string? Product_link { get; set; }
		public string? Sku { get; set; }
		public string? Name { get; set; }
		public int? Price { get; set; }
		public string? Description { get; set; }
		public int? View_count { get; set; }
		public int? Sold_count { get; set; }
		public string? Meta_title { get; set; }
		public string? Meta_keyword { get; set; }
		public DateTime? Created_at { get; set; }
		public DateTime? Updated_at { get; set; }
		public ICollection<Product_variants>? Product_Variants { get; set; }
		public ICollection<Product_parts>? Product_Parts { get; set; }
    }
}
