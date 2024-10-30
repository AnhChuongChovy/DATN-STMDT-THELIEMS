namespace DATN_STMDT_THELIEMS.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public Categories Parent { get; set; }
        public string Name { get; set; } // nvarchar(50)
        public string Image { get; set; } // Text
        public bool Status { get; set; } // Tinyint -> bool
        public string Title { get; set; } // nvarchar(50)
        public string Description { get; set; } // Text
        public string Keyword { get; set; } // nvarchar(30)
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Products> Products { get; set; }

    }
}
