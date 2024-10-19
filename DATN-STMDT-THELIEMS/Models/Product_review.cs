namespace DATN_STMDT_THELIEMS.Models
{
    public class Product_review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderDetailId { get; set; }
        public int Rating { get; set; }
        public int LikeCount { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
