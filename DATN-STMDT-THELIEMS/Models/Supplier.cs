namespace DATN_STMDT_THELIEMS.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public ICollection<Products> Products { get; set; }

    }
}
