namespace DATN_STMDT_THELIEMS.Models
{
    public class Delivery_address
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public Users Users { get; set; }
        public int Province_Id { get; set; }
        public int District_Id { get; set; }
        public int Ward_Id { get; set; }
        public string FullAddress { get; set; }
        public byte Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
    }
}
