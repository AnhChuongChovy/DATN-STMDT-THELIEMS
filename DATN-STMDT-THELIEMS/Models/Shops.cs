namespace DATN_STMDT_THELIEMS.Models
{
    public class Shops
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public Users Users { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<User_shop_follow> User_Shop_Follows { get; set; }
        public ICollection<User_shop_rating> User_Shop_Ratings { get; set; }
        public ICollection<Products> Products { get; set; }
        public ICollection<Orders> Orders { get; set; }

    }
}
