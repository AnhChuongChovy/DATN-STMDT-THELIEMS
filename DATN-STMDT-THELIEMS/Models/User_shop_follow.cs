namespace DATN_STMDT_THELIEMS.Models
{
    public class User_shop_follow
    {
        public int ID { get; set; }
        public int User_id { get; set; }
        public int Shop_id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
