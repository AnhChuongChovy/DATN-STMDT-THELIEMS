namespace DATN_STMDT_THELIEMS.Models
{
    public class Product_part_image
    {
        public int Id { get; set; }
        public int Product_part_id { get; set; }
        public Product_parts Product_part { get; set; }
        public string Image { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
