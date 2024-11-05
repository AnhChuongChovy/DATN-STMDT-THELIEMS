using DATN_STMDT_THELIEMS.DATA;
using DATN_STMDT_THELIEMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DATN_STMDT_THELIEMS.Areas.Shop.Controllers
{
	[Area("Shop")]
	[Route("Shop/[controller]/[action]")]
	public class ProductsController : Controller
	{
		private readonly AppDBContext _context;

		public ProductsController(AppDBContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult IndexShop()
		{
			//gọi danh sách sp có thêm danh mục
			var products = _context.PRODUCTS
							  .Include(c => c.Categories)
							  .Include(a => a.Product_Variants)
							  .ToList();
			var categories = _context.CATEGORIES.ToList();
			ViewBag.Categories = categories;
			ViewBag.Products = products;

			int totalProducts = products.Count; //Tổng sp 
			int sellingProductCount = products.Count(p => p.Status == 1); //Sp đang bán
			int noQuantityProductCount = products.Count(p => p.TotalQuantity == 0); //Sp hết hàng
			
			// Truyền dữ liệu qua ViewBag
			ViewBag.SellingProductCount = sellingProductCount;
			ViewBag.NoQuantityProductCount = noQuantityProductCount;
			ViewBag.TotalProducts = totalProducts;

			return View(products);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> DetailProduct(int id)
		{
			// Lấy sản phẩm từ database bao gồm các biến thể và các tùy chọn biến thể
			var product = _context.PRODUCTS
				.Include(p => p.Product_Variants) //khoá ngoại để gọi biến thể
					.ThenInclude(v => v.Product_Variant_Options) //khoá ngoại để gọi giá trị biến thẻ
						.ThenInclude(o => o.variant_values) //khoá ngoại để gọi biến thể
							.ThenInclude(vv => vv.Variant_Options)
				.Include(p => p.Categories)//khoá ngoại để gọi danh mục của sp 
				.FirstOrDefault(p => p.Id == id);

			if (product == null)
			{
				return NotFound();
			}
			var categories = _context.CATEGORIES.ToList();
			ViewBag.Categories = categories;
			return View(product);
		}

        [HttpPost]
        [Route("{id}")]
		public async Task<IActionResult> DetailProduct(int id, Products updatedProduct)
		{
			if (id != updatedProduct.Id)
			{
				return BadRequest();
			}

			// Validate the model
			if (!ModelState.IsValid)
			{
				var product = await _context.PRODUCTS
					.Include(p => p.Product_Variants)
						.ThenInclude(v => v.Product_Variant_Options)
							.ThenInclude(o => o.variant_values)
								.ThenInclude(vv => vv.Variant_Options)
					.Include(p => p.Categories)
					.FirstOrDefaultAsync(p => p.Id == id);
				ViewBag.Categories = await _context.CATEGORIES.ToListAsync();
				return View(product);
			}

			// Update the product in the database
			_context.PRODUCTS.Update(updatedProduct);
			await _context.SaveChangesAsync();

			// Redirect to the detail view of the updated product
			return RedirectToAction("DetailProduct", "Products", new { area = "Shop", id = updatedProduct.Id });
			//return RedirectToAction("DetailProduct", new { id = updatedProduct.Id });
		}


		[HttpGet]
		public IActionResult AddProduct()
		{
			// Lấy danh sách danh mục để hiển thị trong dropdown
			ViewBag.Categories = _context.CATEGORIES.ToList();
			return View();
		}
		[HttpPost]
		public IActionResult AddProduct(Products product, IFormFile Image)
		{
			if (product == null) // Kiểm tra xem product có null không
			{
				Console.WriteLine("Product is null");
				return View();
			}
			if (!ModelState.IsValid)
			{
				// Kiểm tra các lỗi trong ModelState
				var errors = ModelState.Values.SelectMany(v => v.Errors);
				foreach (var error in errors)
				{
					Console.WriteLine(error.ErrorMessage); // Hoặc ghi log lỗi
				}

				ViewBag.Categories = _context.CATEGORIES.ToList();
				return View(product);
			}

			//Kiểm tra hình ảnh có được chọn hay không

			if (Image != null && Image.Length > 0)
			{
				// Lưu hình ảnh vào thư mục wwwroot/images
				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", Image.FileName);
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					Image.CopyTo(stream);
				}
				product.Image = Image.FileName; // Lưu tên hình ảnh vào sản phẩm
			}

			// Gán các thuộc tính khác cho sản phẩm
			product.Category_id = 5;
			product.Supplier_id = 1;
			product.Shop_id = 1;
			product.Brand_id = 1;
			product.Product_link = "dâds";
			product.Sku = "dddddđ";
			product.Price = 0;
			product.View_count = 0;
			product.Sold_count = 0;
			product.Meta_title = "dâda";
			product.Meta_keyword = "dâdad";
			product.Created_at = DateTime.Now; // Gán thời gian hiện tại cho Created_at
			product.Updated_at = DateTime.Now; // Gán thời gian hiện tại cho Updated_at
											   // Lưu sản phẩm vào cơ sở dữ liệu

			_context.PRODUCTS.Add(product);
			_context.SaveChanges();

			return RedirectToAction("IndexShop", "Products", new { area = "Shop" });
		}
		
		[HttpGet]
		public IActionResult Delete(int id)
		{
			var product = _context.PRODUCTS.Find(id);
			if (product == null)
			{
				return NotFound();  // Nếu sản phẩm không tồn tại
			}

			// Thay đổi trạng thái sản phẩm (ví dụ: từ 1 sang 0)
			product.Status = 0; 
			_context.SaveChanges(); 

			// Chuyển hướng về trang danh sách sản phẩm (IndexShop)
			return RedirectToAction("IndexShop", "Products", new { area = "Shop" });
		}
	}
}
