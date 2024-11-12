using DATN_STMDT_THELIEMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace DATN_STMDT_THELIEMS.DATA
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Role> ROLES { get; set; }
        public DbSet<Permission> PERMISSIONS { get; set; }

        public DbSet<Role_Permission> ROLE_PERMISSIONS { get; set; }
        public DbSet<Users> USERS { get; set; }
        public DbSet<Shops> SHOPS { get; set; }
        public DbSet<Delivery_address> DELIVERY_ADDRESSES { get; set; }
        public DbSet<User_shop_follow> USER_SHOP_FOLLOWS { get; set; }
        public DbSet<User_shop_rating> USER_SHOP_RATINGS { get; set; }
        public DbSet<Brands> BRANDS { get; set; }
        public DbSet<Categories> CATEGORIES { get; set; }
        public DbSet<Supplier> SUPPLIERS { get; set; }
        public DbSet<Order_details> ORDER_DETAILS { get; set; }
        public DbSet<Orders> ORDERS { get; set; }
        public DbSet<Products> PRODUCTS { get; set; }

        public DbSet<Product_Image> PRODUCT_IMAGES { get; set; }
        public DbSet<Product_part_image> PRODUCT_PART_IMAGES { get; set; }
        public DbSet<Product_parts> PRODUCT_PARTS { get; set; }
        public DbSet<Product_review> PRODUCT_REVIEWS { get; set; }
        public DbSet<Review_media> REVIEW_MEDIAS { get; set; }
        public DbSet<Product_variant_option> PRODUCT_VARIANT_OPTIONS { get; set; }
        public DbSet<Product_variants> PRODUCT_VARIANTS { get; set; }
        public DbSet<Variant_options> VARIANT_OPTIONS { get; set; }
        public DbSet<Variant_values> VARIANT_VALUES { get; set; }
        public DbSet<Voucher> VOUCHERS { get; set; }
        public DbSet<Attributes> ATTRIBUTES { get; set; }
        public DbSet<Product_attribute> PRODUCT_ATTRIBUTE { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role_Permission>()
                .HasOne(x => x.Permission)
                .WithMany(c => c.Role_Permissions)
                .HasForeignKey(x => x.Permission_id);

            modelBuilder.Entity<Role_Permission>()
                .HasOne(x => x.Role)
                .WithMany(c => c.Role_Permissions)
                .HasForeignKey(x => x.Role_id);

            modelBuilder.Entity<Users>()
                .HasOne(x => x.Role)
                .WithMany(c => c.Users)
                .HasForeignKey(x => x.Role_id);

            modelBuilder.Entity<Users>()
                .HasOne(x => x.Shops)
                .WithOne(c => c.Users)
                .HasForeignKey<Shops>(x => x.User_id);

            modelBuilder.Entity<Delivery_address>()
                .HasOne(x => x.Users)
                .WithMany(c => c.Delivery_Addresses)
                .HasForeignKey(x => x.User_id);

            modelBuilder.Entity<User_shop_follow>()
                .HasOne(x => x.Shops)
                .WithMany(c => c.User_Shop_Follows)
                .HasForeignKey(x => x.Shop_id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User_shop_rating>()
                .HasOne(x => x.Shops)
                .WithMany(c => c.User_Shop_Ratings)
                .HasForeignKey(x => x.Shop_id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User_shop_follow>()
                .HasOne(x => x.Users)
                .WithMany(c => c.User_Shop_Follows)
                .HasForeignKey(x => x.User_id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User_shop_rating>()
                .HasOne(x => x.Users)
                .WithMany(c => c.User_Shop_Ratings)
                .HasForeignKey(x => x.User_id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Categories>()
            .HasOne(c => c.Parent)
            .WithMany()
            .HasForeignKey(c => c.Parent_id)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Products>()
                .HasOne(p => p.Categories)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.Category_id);

            modelBuilder.Entity<Products>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.Supplier_id);

            modelBuilder.Entity<Products>()
                .HasOne(p => p.Shops)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.Shop_id);

            modelBuilder.Entity<Products>()
                .HasOne(p => p.Brands)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.Brand_id);

            modelBuilder.Entity<Product_parts>()
                .HasOne(p => p.Products)
                .WithMany(b => b.Product_Parts)
                .HasForeignKey(p => p.Product_id);

            modelBuilder.Entity<Product_part_image>()
                .HasOne(p => p.Product_part)
                .WithMany(b => b.Product_Part_Images)
                .HasForeignKey(p => p.Product_part_id);

            modelBuilder.Entity<Product_variant_option>()
                .HasOne(p => p.variant_values)
                .WithMany(b => b.Product_Variant_Options)
                .HasForeignKey(p => p.Variant_value_id);

            modelBuilder.Entity<Product_variant_option>()
                .HasOne(p => p.product_Variants)
                .WithMany(b => b.Product_Variant_Options)
                .HasForeignKey(p => p.Product_variant_id);

            modelBuilder.Entity<Product_variants>()
                .HasOne(p => p.Products)
                .WithMany(b => b.Product_Variants)
                .HasForeignKey(p => p.Product_id);

            modelBuilder.Entity<Product_Image>()
                .HasOne(p => p.product_Variants)
                .WithMany(b => b.Product_Images)
                .HasForeignKey(p => p.Product_variant_id);

            modelBuilder.Entity<Orders>()
                .HasOne(p => p.Users)
                .WithMany(b => b.Orders)
                .HasForeignKey(p => p.User_id);

            modelBuilder.Entity<Orders>()
                .HasOne(p => p.Voucher)
                .WithMany(b => b.Orders)
                .HasForeignKey(p => p.Voucher_id);

            modelBuilder.Entity<Orders>()
                .HasOne(p => p.Shops)
                .WithMany(b => b.Orders)
                .HasForeignKey(p => p.Shop_id);

            modelBuilder.Entity<Order_details>()
                .HasOne(p => p.Orders)
                .WithMany(b => b.Order_Details)
                .HasForeignKey(p => p.Order_id);

            modelBuilder.Entity<Order_details>()
                .HasOne(p => p.Product_variants)
                .WithMany(b => b.Order_Details)
                .HasForeignKey(p => p.Product_variant_id);

            modelBuilder.Entity<Product_review>()
                .HasOne(x => x.User)
                .WithMany(c => c.Product_Reviews)
                .HasForeignKey(x => x.User_id);

            modelBuilder.Entity<Product_review>()
                .HasOne(p => p.Order_details)
                .WithMany(b => b.Product_Reviews)
                .HasForeignKey(p => p.Order_detail_id);

            modelBuilder.Entity<Review_media>()
                .HasOne(x => x.product_Review)
                .WithMany(c => c.Review_Medias)
                .HasForeignKey(x => x.Review_id);

            modelBuilder.Entity<Variant_values>()
                .HasOne(p => p.Variant_Options)
                .WithMany(b => b.Variant_values)
                .HasForeignKey(p => p.Variant_option_id);

            modelBuilder.Entity<Attributes>()
                .HasOne(p => p.Category)
                .WithMany(a => a.Attribute)
                .HasForeignKey(p => p.Category_id);

            modelBuilder.Entity<Product_attribute>()
                .HasOne(p => p.Attributes)
                .WithMany(a => a.product_Attributes)
                .HasForeignKey(p => p.Attribute_id);

            modelBuilder.Entity<Product_attribute>()
                .HasOne(p => p.Products)
                .WithMany(a => a.product_Attributes)
                .HasForeignKey(p => p.Product_id);
        }

    }
}
