namespace DATN_STMDT_THELIEMS.Models
{
    public class Variant_values
    {
        public int Id { get; set; }
        public int? Variant_option_id { get; set; }
        public Variant_options? Variant_Options { get; set; }
        public string? Name { get; set; }
        public ICollection<Product_variant_option>? Product_Variant_Options { get; set; }

    }
}
