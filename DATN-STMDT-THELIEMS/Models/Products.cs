namespace DATN_STMDT_THELIEMS.Models
{
    public class Products
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public int ShopId { get; set; }
        public int BrandId { get; set; }
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
    }
}
