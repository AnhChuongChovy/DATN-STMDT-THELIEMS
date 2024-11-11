using DATN_STMDT_THELIEMS.DATA;
using DATN_STMDT_THELIEMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DATN_STMDT_THELIEMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDBContext _context;

        public CategoryController(AppDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult IndexCategory(string query, int page = 1, int pageSize = 6)
        {
            var categories = _context.CATEGORIES.AsQueryable();

            if (!string.IsNullOrEmpty(query))
            {
                categories = categories.Where(c => c.Name.Contains(query));
            }
            // Đếm tổng số danh mục sau khi lọc và phân trang
            int totalCategories = categories.Count();

            // Tính toán số lượng trang dựa trên kích thước trang (Tổng / số lượng hiển thị trong bảng: ví dụ: tổng 60/10 = 6 trang)
            int totalPages = (int)Math.Ceiling(totalCategories / (double)pageSize);

            // Phân trang dữ liệu
            var paginatedCategories = categories
                .Skip((page - 1) * pageSize) //bỏ qua những danh mục trang đầu ví dụ: 1 trang có 10 thì trang 2 sẽ bỏ qua 10 danh mục đầu và lấy danh mục thứ 11
                .Take(pageSize) //Số lượng danh mục cho mỗi trang 
                .ToList();

            int stt = (page - 1) * pageSize + 1;

            ViewData["SearchQuery"] = query;
            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = totalPages;
            ViewData["ItemsPerPage"] = pageSize;

			var selectCategorie = _context.CATEGORIES.ToList();

			// Truyền danh sách vào ViewBag
			ViewBag.Categories = selectCategorie;
			return View(paginatedCategories);
        }


        [HttpPost]
        public IActionResult CreateCategory(Categories category, IFormFile imageFile)
        {
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
                category.Image = "images/" + fileName;
            }

            category.Created_at = DateTime.Now;
            category.Updated_at = DateTime.Now;

            _context.CATEGORIES.Add(category);
            _context.SaveChanges();
            return RedirectToAction("IndexCategory");
        }
        [HttpPost]
        [Route("{id}")]
        public IActionResult HideCategory(int id)
        {
            // Tìm danh mục theo Id
            var category = _context.CATEGORIES.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            // Cập nhật trạng thái thành 0
            category.Status = 0;
            _context.SaveChanges();

            // Chuyển hướng về trang danh sách danh mục
            return RedirectToAction("IndexCategory");
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult DisplayCategory(int id)
        {
            // Tìm danh mục theo Id
            var category = _context.CATEGORIES.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            // Cập nhật trạng thái thành 0
            category.Status = 1;
            _context.SaveChanges();

            // Chuyển hướng về trang danh sách danh mục
            return RedirectToAction("IndexCategory");
        }

        [HttpGet("{id}")]
        public IActionResult EditCategoryForm(int id)
        {
            var category = _context.CATEGORIES.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            ViewBag.AllCategories = _context.CATEGORIES.ToList();
            return View("EditCategory", category);
        }
        [HttpPost]
        public IActionResult EditCategory(Categories categories, IFormFile imageFile)
        {
            var category = _context.CATEGORIES.FirstOrDefault(c => c.Id == categories.Id);
            if (category == null)
            {
                return NotFound();
            }
            if (imageFile != null && imageFile.Length > 0)
            {
                var validExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(imageFile.FileName).ToLower();

                if (!validExtensions.Contains(extension))
                {
                    ModelState.AddModelError("Image", "Định dạng ảnh không hợp lệ. Các định dạng được phép: .jpg, .jpeg, .png, .gif.");
                    return View(categories); // Trả về view với lỗi nếu có
                }

                var fileName = Guid.NewGuid().ToString() + extension;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyToAsync(stream);
                }

                category.Image = "images/" + fileName;
            }
            category.Name = categories.Name;
            category.Parent_id = categories.Parent_id;
            category.Status = categories.Status;
            category.Title = categories.Title;
            category.Keyword = categories.Keyword;
            category.Description = categories.Description;
            category.Updated_at = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("IndexCategory"); // Redirect back to the list of categories
        }
    }
}
