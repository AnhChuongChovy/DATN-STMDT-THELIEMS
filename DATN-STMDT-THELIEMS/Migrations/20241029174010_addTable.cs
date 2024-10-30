using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATN_STMDT_THELIEMS.Migrations
{
    public partial class addTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BRANDS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANDS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parent_id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keyword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CATEGORIES_CATEGORIES_Parent_id",
                        column: x => x.Parent_id,
                        principalTable: "CATEGORIES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PERMISSIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSIONS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VARIANT_OPTIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VARIANT_OPTIONS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ROLE_PERMISSIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_id = table.Column<int>(type: "int", nullable: false),
                    Permission_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_PERMISSIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ROLE_PERMISSIONS_PERMISSIONS_Permission_id",
                        column: x => x.Permission_id,
                        principalTable: "PERMISSIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ROLE_PERMISSIONS_ROLES_Role_id",
                        column: x => x.Role_id,
                        principalTable: "ROLES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_id = table.Column<int>(type: "int", nullable: false),
                    Is_seller = table.Column<byte>(type: "tinyint", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USERS_ROLES_Role_id",
                        column: x => x.Role_id,
                        principalTable: "ROLES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VARIANT_VALUES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Variant_option_id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VARIANT_VALUES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VARIANT_VALUES_VARIANT_OPTIONS_Variant_option_id",
                        column: x => x.Variant_option_id,
                        principalTable: "VARIANT_OPTIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DELIVERY_ADDRESSES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Province_id = table.Column<int>(type: "int", nullable: false),
                    District_id = table.Column<int>(type: "int", nullable: false),
                    Ward_id = table.Column<int>(type: "int", nullable: false),
                    Full_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DELIVERY_ADDRESSES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DELIVERY_ADDRESSES_USERS_User_id",
                        column: x => x.User_id,
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SHOPS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHOPS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SHOPS_USERS_User_id",
                        column: x => x.User_id,
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VOUCHERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    Voucher_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voucher_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount_type = table.Column<byte>(type: "tinyint", nullable: false),
                    Discount_value = table.Column<int>(type: "int", nullable: false),
                    Max_discount = table.Column<int>(type: "int", nullable: true),
                    Min_order_value = table.Column<int>(type: "int", nullable: false),
                    Start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VOUCHERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VOUCHERS_USERS_UsersId",
                        column: x => x.UsersId,
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_id = table.Column<int>(type: "int", nullable: true),
                    Supplier_id = table.Column<int>(type: "int", nullable: true),
                    Shop_id = table.Column<int>(type: "int", nullable: true),
                    Brand_id = table.Column<int>(type: "int", nullable: true),
                    Product_link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    View_count = table.Column<int>(type: "int", nullable: true),
                    Sold_count = table.Column<int>(type: "int", nullable: true),
                    Meta_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Meta_keyword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_BRANDS_Brand_id",
                        column: x => x.Brand_id,
                        principalTable: "BRANDS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PRODUCTS_CATEGORIES_Category_id",
                        column: x => x.Category_id,
                        principalTable: "CATEGORIES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PRODUCTS_SHOPS_Shop_id",
                        column: x => x.Shop_id,
                        principalTable: "SHOPS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PRODUCTS_SUPPLIERS_Supplier_id",
                        column: x => x.Supplier_id,
                        principalTable: "SUPPLIERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "USER_SHOP_FOLLOWS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Shop_id = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_SHOP_FOLLOWS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USER_SHOP_FOLLOWS_SHOPS_Shop_id",
                        column: x => x.Shop_id,
                        principalTable: "SHOPS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_USER_SHOP_FOLLOWS_USERS_User_id",
                        column: x => x.User_id,
                        principalTable: "USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "USER_SHOP_RATINGS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Shop_id = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_SHOP_RATINGS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USER_SHOP_RATINGS_SHOPS_Shop_id",
                        column: x => x.Shop_id,
                        principalTable: "SHOPS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_USER_SHOP_RATINGS_USERS_User_id",
                        column: x => x.User_id,
                        principalTable: "USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(type: "int", nullable: true),
                    Shop_id = table.Column<int>(type: "int", nullable: true),
                    Voucher_id = table.Column<int>(type: "int", nullable: true),
                    Delivery_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivery_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    Total_price = table.Column<int>(type: "int", nullable: true),
                    Payment_status = table.Column<byte>(type: "tinyint", nullable: true),
                    Payment_method = table.Column<int>(type: "int", nullable: true),
                    Shipping_method = table.Column<int>(type: "int", nullable: true),
                    Order_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Payment_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Discount_amount = table.Column<int>(type: "int", nullable: true),
                    Shipping_cost = table.Column<int>(type: "int", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORDERS_SHOPS_Shop_id",
                        column: x => x.Shop_id,
                        principalTable: "SHOPS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ORDERS_USERS_User_id",
                        column: x => x.User_id,
                        principalTable: "USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ORDERS_VOUCHERS_Voucher_id",
                        column: x => x.Voucher_id,
                        principalTable: "VOUCHERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_PARTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_PARTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCT_PARTS_PRODUCTS_Product_id",
                        column: x => x.Product_id,
                        principalTable: "PRODUCTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_VARIANTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_id = table.Column<int>(type: "int", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_VARIANTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCT_VARIANTS_PRODUCTS_Product_id",
                        column: x => x.Product_id,
                        principalTable: "PRODUCTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_PART_IMAGES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_part_id = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_PART_IMAGES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCT_PART_IMAGES_PRODUCT_PARTS_Product_part_id",
                        column: x => x.Product_part_id,
                        principalTable: "PRODUCT_PARTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_DETAILS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_id = table.Column<int>(type: "int", nullable: true),
                    Product_variant_id = table.Column<int>(type: "int", nullable: true),
                    Product_price = table.Column<int>(type: "int", nullable: true),
                    Product_quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_DETAILS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORDER_DETAILS_ORDERS_Order_id",
                        column: x => x.Order_id,
                        principalTable: "ORDERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ORDER_DETAILS_PRODUCT_VARIANTS_Product_variant_id",
                        column: x => x.Product_variant_id,
                        principalTable: "PRODUCT_VARIANTS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_IMAGES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_variant_id = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_IMAGES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCT_IMAGES_PRODUCT_VARIANTS_Product_variant_id",
                        column: x => x.Product_variant_id,
                        principalTable: "PRODUCT_VARIANTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_VARIANT_OPTIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_variant_id = table.Column<int>(type: "int", nullable: false),
                    Variant_value_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_VARIANT_OPTIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCT_VARIANT_OPTIONS_PRODUCT_VARIANTS_Product_variant_id",
                        column: x => x.Product_variant_id,
                        principalTable: "PRODUCT_VARIANTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCT_VARIANT_OPTIONS_VARIANT_VALUES_Variant_value_id",
                        column: x => x.Variant_value_id,
                        principalTable: "VARIANT_VALUES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_REVIEWS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Order_detail_id = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Like_count = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_REVIEWS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCT_REVIEWS_ORDER_DETAILS_Order_detail_id",
                        column: x => x.Order_detail_id,
                        principalTable: "ORDER_DETAILS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCT_REVIEWS_USERS_User_id",
                        column: x => x.User_id,
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REVIEW_MEDIAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review_id = table.Column<int>(type: "int", nullable: false),
                    Media = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REVIEW_MEDIAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_REVIEW_MEDIAS_PRODUCT_REVIEWS_Review_id",
                        column: x => x.Review_id,
                        principalTable: "PRODUCT_REVIEWS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIES_Parent_id",
                table: "CATEGORIES",
                column: "Parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_DELIVERY_ADDRESSES_User_id",
                table: "DELIVERY_ADDRESSES",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_DETAILS_Order_id",
                table: "ORDER_DETAILS",
                column: "Order_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_DETAILS_Product_variant_id",
                table: "ORDER_DETAILS",
                column: "Product_variant_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_Shop_id",
                table: "ORDERS",
                column: "Shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_User_id",
                table: "ORDERS",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_Voucher_id",
                table: "ORDERS",
                column: "Voucher_id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_IMAGES_Product_variant_id",
                table: "PRODUCT_IMAGES",
                column: "Product_variant_id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_PART_IMAGES_Product_part_id",
                table: "PRODUCT_PART_IMAGES",
                column: "Product_part_id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_PARTS_Product_id",
                table: "PRODUCT_PARTS",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_REVIEWS_Order_detail_id",
                table: "PRODUCT_REVIEWS",
                column: "Order_detail_id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_REVIEWS_User_id",
                table: "PRODUCT_REVIEWS",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_VARIANT_OPTIONS_Product_variant_id",
                table: "PRODUCT_VARIANT_OPTIONS",
                column: "Product_variant_id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_VARIANT_OPTIONS_Variant_value_id",
                table: "PRODUCT_VARIANT_OPTIONS",
                column: "Variant_value_id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_VARIANTS_Product_id",
                table: "PRODUCT_VARIANTS",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_Brand_id",
                table: "PRODUCTS",
                column: "Brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_Category_id",
                table: "PRODUCTS",
                column: "Category_id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_Shop_id",
                table: "PRODUCTS",
                column: "Shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_Supplier_id",
                table: "PRODUCTS",
                column: "Supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_REVIEW_MEDIAS_Review_id",
                table: "REVIEW_MEDIAS",
                column: "Review_id");

            migrationBuilder.CreateIndex(
                name: "IX_ROLE_PERMISSIONS_Permission_id",
                table: "ROLE_PERMISSIONS",
                column: "Permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_ROLE_PERMISSIONS_Role_id",
                table: "ROLE_PERMISSIONS",
                column: "Role_id");

            migrationBuilder.CreateIndex(
                name: "IX_SHOPS_User_id",
                table: "SHOPS",
                column: "User_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USER_SHOP_FOLLOWS_Shop_id",
                table: "USER_SHOP_FOLLOWS",
                column: "Shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_USER_SHOP_FOLLOWS_User_id",
                table: "USER_SHOP_FOLLOWS",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_USER_SHOP_RATINGS_Shop_id",
                table: "USER_SHOP_RATINGS",
                column: "Shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_USER_SHOP_RATINGS_User_id",
                table: "USER_SHOP_RATINGS",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_Role_id",
                table: "USERS",
                column: "Role_id");

            migrationBuilder.CreateIndex(
                name: "IX_VARIANT_VALUES_Variant_option_id",
                table: "VARIANT_VALUES",
                column: "Variant_option_id");

            migrationBuilder.CreateIndex(
                name: "IX_VOUCHERS_UsersId",
                table: "VOUCHERS",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DELIVERY_ADDRESSES");

            migrationBuilder.DropTable(
                name: "PRODUCT_IMAGES");

            migrationBuilder.DropTable(
                name: "PRODUCT_PART_IMAGES");

            migrationBuilder.DropTable(
                name: "PRODUCT_VARIANT_OPTIONS");

            migrationBuilder.DropTable(
                name: "REVIEW_MEDIAS");

            migrationBuilder.DropTable(
                name: "ROLE_PERMISSIONS");

            migrationBuilder.DropTable(
                name: "USER_SHOP_FOLLOWS");

            migrationBuilder.DropTable(
                name: "USER_SHOP_RATINGS");

            migrationBuilder.DropTable(
                name: "PRODUCT_PARTS");

            migrationBuilder.DropTable(
                name: "VARIANT_VALUES");

            migrationBuilder.DropTable(
                name: "PRODUCT_REVIEWS");

            migrationBuilder.DropTable(
                name: "PERMISSIONS");

            migrationBuilder.DropTable(
                name: "VARIANT_OPTIONS");

            migrationBuilder.DropTable(
                name: "ORDER_DETAILS");

            migrationBuilder.DropTable(
                name: "ORDERS");

            migrationBuilder.DropTable(
                name: "PRODUCT_VARIANTS");

            migrationBuilder.DropTable(
                name: "VOUCHERS");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "BRANDS");

            migrationBuilder.DropTable(
                name: "CATEGORIES");

            migrationBuilder.DropTable(
                name: "SHOPS");

            migrationBuilder.DropTable(
                name: "SUPPLIERS");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "ROLES");
        }
    }
}
