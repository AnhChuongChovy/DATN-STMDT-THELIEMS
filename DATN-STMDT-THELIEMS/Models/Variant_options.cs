namespace DATN_STMDT_THELIEMS.Models
{
    public class Variant_options
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Variant_values>? Variant_values { get; set; }

    }
}
