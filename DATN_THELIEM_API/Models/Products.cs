
using System.ComponentModel.DataAnnotations;

namespace DATN_THELIEM_API.Models
{
	public class Products
	{
		public int Id { get; set; }
        public int? Category_id { get; set; }
        public Categories Categories { get; set; }
        public int? Supplier_id { get; set; }
        public Supplier Supplier { get; set; }
        public int? Shop_id { get; set; }
        public Shops Shops { get; set; }
        public int? Brand_id { get; set; }
        public Brands Brands { get; set; }
        public string? Product_link { get; set; }
        [Required(ErrorMessage = "SKU sản phẩm không được để trống.")]
        [MaxLength(120, ErrorMessage = "SKU sản phẩm không được vượt quá 20 ký tự.")]
        public string? Sku { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm không được để trống.")]
        [MaxLength(120, ErrorMessage = "Tên sản phẩm không được vượt quá 120 ký tự.")]
        public string? Name { get; set; }
		public string? Image { get; set; }
		public int Price { get; set; }
        public string? Description { get; set; }
        public int? View_count { get; set; }
        public int? Sold_count { get; set; }
        public string? Meta_title { get; set; }
        public string? Meta_keyword { get; set; }
        public byte? Status { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public ICollection<Product_variants> Product_Variants { get; set; }
        public ICollection<Product_parts> Product_Parts { get; set; }
		public int TotalQuantity => Product_Variants?.Sum(v => v.Quantity) ?? 0;

	}
}
