namespace DATN_STMDT_THELIEMS.Models
{
    public class Product_Image
    {
        public int Id { get; set; }
        public int Product_variant_id { get; set; }
        public Product_variants product_Variants { get; set; }
        public string Image { get; set; }
    }
}
