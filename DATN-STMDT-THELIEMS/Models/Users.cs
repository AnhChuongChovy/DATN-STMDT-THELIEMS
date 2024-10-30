namespace DATN_STMDT_THELIEMS.Models
{
    public class Users
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public byte? Is_seller { get; set; }
        public string Password { get; set; }
        public string Full_name { get; set; }
        public string? Gender { get; set; }
        public string? Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Image { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public Shops Shops { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<Voucher> Vouchers { get; set; }

        public ICollection<Delivery_address> Delivery_Addresses { get; set; }
        public ICollection<User_shop_follow> User_Shop_Follows { get; set; }
        public ICollection<User_shop_rating> User_Shop_Ratings { get; set; }
        public ICollection<Product_review> Product_Reviews { get; set; }


    }
}
