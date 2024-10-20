namespace DATN_STMDT_THELIEMS.Models
{
    public class Brands
    {
        public int Id { get; set; }
        public string Name { get; set; } // nvarchar(50)
        public string Description { get; set; } // Text
        public string Image { get; set; } // Text
        public bool Status { get; set; } // Tinyint -> bool
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Products> Products { get; set; }

    }
}
