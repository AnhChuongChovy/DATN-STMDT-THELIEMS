namespace DATN_STMDT_THELIEMS.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int? User_id { get; set; }
        public Users? Users { get; set; }
        public int? Shop_id { get; set; }
        public Shops? Shops { get; set; }
        public int? Voucher_id { get; set; }
        public Voucher? Voucher { get; set; }
        public string? Delivery_address { get; set; } 
        public DateTime? Delivery_date { get; set; }
        public byte? Status { get; set; } 
        public int? Total_price { get; set; } 
        public byte? Payment_status { get; set; } 
        public int? Payment_method { get; set; } 
        public int? Shipping_method { get; set; }
        public DateTime? Order_time { get; set; }
        public DateTime? Payment_time { get; set; } 
        public int? Discount_amount { get; set; }
        public int? Shipping_cost { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public ICollection<Order_details>? Order_Details { get; set; }
		public int TotalProductPrice => Order_Details?.Sum(od => od.TotalPrice) ?? 0;

        //public int TotalAmount => 

	}
}
