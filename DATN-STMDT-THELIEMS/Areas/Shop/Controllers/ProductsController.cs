using DATN_STMDT_THELIEMS.DATA;
using DATN_STMDT_THELIEMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
		public IActionResult IndexShop(int page = 1, int pageSize = 5, string searchTerm = "", int? categoryId = null)
		{
			//gọi danh sách sp có thêm danh mục
			var products = _context.PRODUCTS
							  .Include(c => c.Categories)
							  .Include(a => a.Product_Variants)
							  .AsQueryable();

			if (!string.IsNullOrEmpty(searchTerm))
			{
				products = products.Where(p => p.Name.Contains(searchTerm));
			}

			if (categoryId.HasValue)
			{
				products = products.Where(p => p.Category_id == categoryId.Value);
			}

			var categories = _context.CATEGORIES.ToList();
			
			var productList = products.ToList();

			int totalProducts = productList.Count(); //Tổng sp 
			int sellingProductCount = productList.Count(p => p.Status == 1); //Sp đang bán
			int noQuantityProductCount = productList.Count(p => p.TotalQuantity == 0); //Sp hết hàng

            // Đếm tổng số sản phẩm sau khi lọc và phân trang
            int total_Products = products.Count();

            // Tính toán số lượng trang dựa trên kích thước trang (Tổng / số lượng hiển thị trong bảng: ví dụ: tổng 60/10 = 6 trang)
            int totalPages = (int)Math.Ceiling(total_Products / (double)pageSize);

            // Phân trang dữ liệu
            var paginatedProducts = products
                .Skip((page - 1) * pageSize) //bỏ qua những sản phẩm trang đầu ví dụ: 1 trang có 10 thì trang 2 sẽ bỏ qua 10 sản phẩm đầu và lấy sản phẩm thứ 11
                .Take(pageSize) //Số lượng sản phẩm cho mỗi trang 
                .ToList();

            int stt = (page - 1) * pageSize + 1;

			// Truyền dữ liệu qua ViewBag
			ViewBag.Categories = categories;
			ViewBag.Products = paginatedProducts;
			ViewBag.SellingProductCount = sellingProductCount;
			ViewBag.NoQuantityProductCount = noQuantityProductCount;
			ViewBag.TotalProducts = totalProducts;

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = totalPages;
            ViewData["ItemsPerPage"] = pageSize;
			ViewData["StartIndex"] = stt;
			ViewData["SearchTerm"] = searchTerm;
			ViewData["SelectedCategory"] = categoryId;

			return View(paginatedProducts);
		}

        [HttpGet]
        //[Route("{id}")]
        public async Task<IActionResult> DetailProduct(int id)
        {
            // Get the product including its variants, options, categories, and attributes
            var product = await _context.PRODUCTS
                .Include(p => p.Product_Variants)
                    .ThenInclude(v => v.Product_Variant_Options)
                    .ThenInclude(o => o.variant_values)
                    .ThenInclude(vv => vv.Variant_Options)
                .Include(p => p.Categories)
                .Include(p => p.product_Attributes)
                    .ThenInclude(a => a.Attribute)
                    .ThenInclude(a => a.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            // Get all categories for the dropdown in the view
            var categories = await _context.CATEGORIES.ToListAsync();
            ViewBag.Categories = categories;

            // Return the product to the view
            return View(product);
        }


		[HttpPost]
		[Area("Shop")]
		public async Task<IActionResult> DetailProduct(Products updatedProduct, List<Product_attribute> productsAttribute, IFormFile imageFile)
		{
			// Lấy sản phẩm hiện tại từ cơ sở dữ liệu
			var product = await _context.PRODUCTS
						   .Include(p => p.Product_Variants) 
						   .Include(p => p.product_Attributes) 
						   .FirstOrDefaultAsync(p => p.Id == updatedProduct.Id);
			if (product == null)
			{
				return NotFound();
			}
			
			// Cập nhật các thuộc tính sản phẩm
			product.Name = updatedProduct.Name;
			product.Category_id = updatedProduct.Category_id;
			product.Price = updatedProduct.Price;
			product.Sku = updatedProduct.Sku;
			product.Status = updatedProduct.Status;
			product.Description = updatedProduct.Description;
			product.Updated_at = DateTime.Now;

			// Xử lý nếu có ảnh mới được upload
			if (imageFile != null && imageFile.Length > 0)
			{
				var validExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
				var extension = Path.GetExtension(imageFile.FileName).ToLower();

				if (!validExtensions.Contains(extension))
				{
					ModelState.AddModelError("Image", "Định dạng ảnh không hợp lệ. Các định dạng được phép: .jpg, .jpeg, .png, .gif.");
					ViewBag.Categories = await _context.CATEGORIES.ToListAsync();
					return View(updatedProduct); // Trả về view với lỗi nếu có
				}

				var fileName = Guid.NewGuid().ToString() + extension;
				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await imageFile.CopyToAsync(stream);
				}

				product.Image = "images/" + fileName;
			}
			if (productsAttribute != null && productsAttribute.Any())
			{
				foreach (var updatedAttribute in productsAttribute)
				{
					var existingAttribute = product.product_Attributes
						.FirstOrDefault(pa => pa.Id == updatedAttribute.Id); 

					if (existingAttribute != null)
					{
						existingAttribute.Name = updatedAttribute.Name;
						existingAttribute.Update_at = DateTime.Now;
					}
				}
			}
			// Cập nhật thông tin sản phẩm vào cơ sở dữ liệu
			_context.PRODUCTS.Update(product);
			await _context.SaveChangesAsync();

			// Sau khi cập nhật, quay lại trang chi tiết sản phẩm
			return RedirectToAction("DetailProduct", new { id = product.Id });
		}


		[HttpGet]
		public  IActionResult AddProduct()
		{	
            // Lấy danh sách danh mục để hiển thị trong dropdown
            ViewBag.Categories = _context.CATEGORIES.ToList();
			ViewBag.Product_Attributes = _context.PRODUCT_ATTRIBUTE.ToList();
			ViewBag.Attribute = _context.ATTRIBUTE.ToList();
            ViewBag.Brands = _context.BRANDS.ToList();
			ViewBag.Product_variant = _context.PRODUCTS.FirstOrDefault(p=> p.Id == p.Id);
			ViewBag.Variant_value = _context.VARIANT_VALUES.ToList();
			ViewBag.Variant_option = _context.VARIANT_OPTIONS.ToList();
            return View();
		}
		[HttpPost]
		public IActionResult AddProduct(Products product, IFormFile imageFile)
		{
			if (product == null) // Kiểm tra xem product có null không
			{
				Console.WriteLine("Product is null");
				return View();
			}

			if (imageFile != null && imageFile.Length > 0)
			{
				// Validate the file type (optional)
				var validExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
				var extension = Path.GetExtension(imageFile.FileName).ToLower();

				if (!validExtensions.Contains(extension))
				{
					ModelState.AddModelError("Image", "Invalid image format. Allowed formats: .jpg, .jpeg, .png, .gif.");
					return View();
				}

				// Generate a unique file name
				var fileName = Guid.NewGuid().ToString() + extension;
				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

				// Save the file to wwwroot/images directory
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					imageFile.CopyTo(stream);
				}

				// Set the Image property of the product to the saved file name
				product.Image = "images/" + fileName;
			}

			// Gán các thuộc tính khác cho sản phẩm
			product.Category_id = 5;
			product.Supplier_id = 1;
			product.Shop_id = 5;
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

		[HttpGet]
		public IActionResult Open(int id)
		{
			var product = _context.PRODUCTS.Find(id);
			if (product == null)
			{
				return NotFound();  // Nếu sản phẩm không tồn tại
			}

			// Thay đổi trạng thái sản phẩm (ví dụ: từ 1 sang 0)
			product.Status = 1;

			_context.SaveChanges();

			// Chuyển hướng về trang danh sách sản phẩm (IndexShop)
			return RedirectToAction("IndexShop", "Products", new { area = "Shop" });
		}
	}
}
