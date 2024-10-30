namespace DATN_STMDT_THELIEMS.Models
{
    public class Delivery_address
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public Users Users { get; set; }
        public int Province_id { get; set; }
        public int District_id { get; set; }
        public int Ward_id { get; set; }
        public string Full_address { get; set; }
        public byte Status { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        
    }
}
