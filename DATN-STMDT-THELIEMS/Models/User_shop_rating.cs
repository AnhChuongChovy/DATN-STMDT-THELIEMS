namespace DATN_STMDT_THELIEMS.Models
{
    public class User_shop_rating
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public Users Users { get; set; }
        public int Shop_id { get; set; }
        public Shops Shops { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
