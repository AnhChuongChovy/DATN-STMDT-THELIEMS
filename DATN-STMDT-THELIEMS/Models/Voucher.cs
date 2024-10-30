namespace DATN_STMDT_THELIEMS.Models
{
    public class Voucher
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public Users Users { get; set; }
        public string Voucher_code { get; set; }
        public string Voucher_name { get; set; }
        public byte Discount_type { get; set; }  // Assuming TinyInt corresponds to byte
        public int Discount_value { get; set; }
        public int? Max_discount { get; set; }  // Nullable in case there is no max discount
        public int Min_order_value { get; set; }
        public DateTime? Start_date { get; set; }
        public DateTime? End_date { get; set; }
        public int Quantity { get; set; }
        public byte Status { get; set; }  // Assuming TinyInt corresponds to byte
        public string? Image { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
