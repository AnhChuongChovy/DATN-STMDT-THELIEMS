using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DATN_STMDT_THELIEMS.Models
{
	public class Attributes
	{
		[Key]
		public int Id { get; set; }
		public int? Category_id { get; set; }
		public Categories? Category { get; set; }
		public string? Name { get; set; }
		public DateTime? Create_at { get; set; }
		public DateTime? Update_at { get; set; }
		public ICollection<Product_attribute>? product_Attributes { get; set; }
	}
}
