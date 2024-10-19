namespace DATN_STMDT_THELIEMS.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int Use_id { get; set; }
        public int Shop_id { get; set; }
        public int? Voucher_id { get; set; } 
        public string DeliveryAddress { get; set; } 
        public DateTime DeliveryDate { get; set; }
        public bool Status { get; set; } 
        public decimal TotalPrice { get; set; } 
        public bool PaymentStatus { get; set; } 
        public int PaymentMethod { get; set; } 
        public int ShippingMethod { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime? PaymentTime { get; set; } 
        public decimal DiscountAmount { get; set; }
        public decimal ShippingCost { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
