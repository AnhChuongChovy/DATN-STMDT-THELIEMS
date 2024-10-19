namespace DATN_STMDT_THELIEMS.Models
{
    public class Order_details
    {
        public int Id { get; set; }
        public int Order_id { get; set; }
        public int Product_variant_id { get; set; }
        public int ProductPrice { get; set; } 
        public int ProductQuantity { get; set; }
    }
}
