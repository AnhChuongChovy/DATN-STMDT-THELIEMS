namespace DATN_STMDT_THELIEMS.Models
{
    public class Product_parts
    {
        public int Id { get; set; }
        public int Product_id { get; set; }
        public Products Products { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Review_media> Review_Medias { get; set; }

    }
}
