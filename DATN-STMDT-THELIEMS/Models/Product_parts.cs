namespace DATN_STMDT_THELIEMS.Models
{
    public class Product_parts
    {
        public int Id { get; set; }
        public int Product_id { get; set; }
        public Products Products { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public ICollection<Product_part_image> Product_Part_Images { get; set; }

    }
}
