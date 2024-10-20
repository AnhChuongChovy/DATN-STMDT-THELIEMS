namespace DATN_STMDT_THELIEMS.Models
{
    public class Voucher
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public Users Users { get; set; }
        public string VoucherCode { get; set; }
        public string VoucherName { get; set; }
        public byte DiscountType { get; set; }  // Assuming TinyInt corresponds to byte
        public int DiscountValue { get; set; }
        public int? MaxDiscount { get; set; }  // Nullable in case there is no max discount
        public int MinOrderValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }  // Assuming TinyInt corresponds to byte
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
