using DATN_STMDT_THELIEMS.DATA;
using DATN_STMDT_THELIEMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DATN_STMDT_THELIEMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly AppDBContext _context;

        public CategoryController(AppDBContext context)
        {
            _context = context;
        }
        [HttpGet]
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

            int stt = (page - 1) * pageSize +1;

            ViewData["SearchQuery"] = query;
            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = totalPages;
            ViewData["ItemsPerPage"] = pageSize;

            return View(paginatedCategories);
        }


        [HttpPost]
        public IActionResult CreateCategory(Categories category)
        {
            if (ModelState.IsValid)
            {
                category.Created_at = DateTime.Now;
                category.Updated_at = DateTime.Now;

                _context.CATEGORIES.Add(category);
                _context.SaveChanges();

                return RedirectToAction("IndexCategory");
            }

            // Nếu model không hợp lệ, gán lại ViewData["ParentCategories"]
            var parentCategories = _context.CATEGORIES.Where(c => c.Parent_id == null).ToList();
            ViewData["ParentCategories"] = new SelectList(parentCategories, "Id", "Name");

            // Trả về View để hiển thị lại form với danh mục cha
            return View(category);
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


        //cập nhật danh mục
        [HttpPost]
        public IActionResult EditCategory(Categories model)
        {
            var category = _context.CATEGORIES.FirstOrDefault(c => c.Id == model.Id);
            if (category == null)
            {
                return NotFound();
            }

            category.Name = model.Name;
            category.Parent_id = model.Parent_id;
            category.Status = model.Status;
            category.Image = model.Image;
            category.Title = model.Title;
            category.Keyword = model.Keyword;
            category.Description = model.Description;

            _context.SaveChanges();
            return RedirectToAction("IndexCategory");
        }

    }
}
