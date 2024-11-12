using System.ComponentModel.DataAnnotations;

namespace DATN_STMDT_THELIEMS.Models
{
    public class Attributes
    {
        [Key]
        public int Id { get; set; }
        public int Category_id { get; set; }
        public Categories? Category { get; set; }
        public string Name { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public ICollection<Product_attribute> product_Attributes { get; set; }
    }
}
