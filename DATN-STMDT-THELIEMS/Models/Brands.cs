namespace DATN_STMDT_THELIEMS.Models
{
    public class Brands
    {
        public int Id { get; set; }
        public string? Name { get; set; } // nvarchar(50)
        public string? Description { get; set; } // Text
        public string? Image { get; set; } // Text
        public byte? Status { get; set; } // Tinyint -> bool
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public ICollection<Products>? Products { get; set; }

    }
}
