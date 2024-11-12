using System.ComponentModel.DataAnnotations;

namespace DATN_STMDT_THELIEMS.Models
{
    public class Product_attribute
    {
        [Key]
        public int Id { get; set; }
        public int Attribute_id { get; set; }
        public Attributes Attributes { get; set; }
        public int Product_id { get; set; }
        public Products Products { get; set; }
        public string Name { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
