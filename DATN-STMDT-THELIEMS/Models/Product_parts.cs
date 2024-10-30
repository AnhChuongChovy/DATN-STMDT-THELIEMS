namespace DATN_STMDT_THELIEMS.Models
{
    public class Product_parts
    {
        public int Id { get; set; }
        public int Product_id { get; set; }
        public Products Products { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Product_part_image> Product_Part_Images { get; set; }

    }
}
