namespace DATN_STMDT_THELIEMS.Models
{
    public class Review_media
    {
        public int Id { get; set; }
        public int Review_id { get; set; }
        public Product_review product_Review { get; set; }
        public string Media { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
