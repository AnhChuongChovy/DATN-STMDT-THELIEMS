namespace DATN_STMDT_THELIEMS.Models
{
    public class Product_review
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public Users User { get; set; }
        public int Order_detail_id { get; set; }
        public Order_details Order_details { get; set; }
        public int Rating { get; set; }
        public int Like_count { get; set; }
        public string Comment { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public ICollection<Review_media> Review_Medias { get; set; }

    }
}
