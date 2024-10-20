using DATN_STMDT_THELIEMS.Models;
using Microsoft.EntityFrameworkCore;
namespace DATN_STMDT_THELIEMS.DATA
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options) { }

        public DbSet<Users> USERS { get; set; }
        public DbSet<Brands> BRANDS { get; set; }
        public DbSet<Categories> CATEGORIES { get; set; }
        public DbSet<Delivery_address> DELIVERY_ADDRESSES { get; set; }
        public DbSet<Order_details> ORDER_DETAILS { get; set; }
        public DbSet<Orders> ORDERS { get; set; }
        public DbSet<Permission> PERMISSIONS { get; set; }
        public DbSet<Product_Image> PRODUCT_IMAGES { get; set; }
        public DbSet<Product_part_image> PRODUCT_PART_IMAGES { get; set; }
        public DbSet<Product_parts> PRODUCT_PARTS { get; set; }
        public DbSet<Product_review> PRODUCT_REVIEWS { get; set; }
        public DbSet<Product_variant_option> PRODUCT_VARIANT_OPTIONS { get; set; }
        public DbSet<Product_variants> PRODUCT_VARIANTS { get; set; }
        public DbSet<Products> PRODUCTS { get; set; }
        public DbSet<Review_media> REVIEW_MEDIAS { get; set; }
        public DbSet<Role> ROLES { get; set; }
        public DbSet<Role_Permission> ROLE_PERMISSIONS { get; set; }
        public DbSet<Shops> SHOPS { get; set; }
        public DbSet<Supplier> SUPPLIERS { get; set; }
        public DbSet<User_shop_follow> USER_SHOP_FOLLOWS { get; set; }
        public DbSet<User_shop_rating> USER_SHOP_RATINGS { get; set; }
        public DbSet<Variant_options> VARIANT_OPTIONS { get; set; }
        public DbSet<Variant_values> VARIANT_VALUES { get; set; }
        public DbSet<Voucher> VOUCHERS { get; set; }
    }
}
    