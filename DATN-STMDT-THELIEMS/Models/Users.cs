namespace DATN_STMDT_THELIEMS.Models
{
    public class Users
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public bool IsSeller { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Shops> Shops { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<Voucher> Vouchers { get; set; }

        public ICollection<Delivery_address> Delivery_Addresses { get; set; }
        public ICollection<User_shop_follow> User_Shop_Follows { get; set; }
        public ICollection<User_shop_rating> User_Shop_Ratings { get; set; }
        public ICollection<Product_review> Product_Reviews { get; set; }


    }
}
