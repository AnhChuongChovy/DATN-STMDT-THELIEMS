namespace DATN_STMDT_THELIEMS.Models
{
    public class Product_variant_option
    {
        public int Id { get; set; }
        public int? Product_variant_id { get; set; }
        public Product_variants? product_Variants { get; set; }
        public int? Variant_value_id { get; set; }
        public Variant_values? variant_values { get; set; }
    }
}
