using DATN_STMDT_THELIEMS.DATA;
using DATN_STMDT_THELIEMS.Models;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DATN_STMDT_THELIEMS.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]")]
	public class AccountController : Controller
	{
		private readonly AppDBContext _context;

		public AccountController(AppDBContext context)
		{
			_context = context;
		}
		public IActionResult AccountIndex(string query, int page = 1, int pageSize = 5)
		{
            var users = _context.USERS.AsQueryable();

            if (!string.IsNullOrEmpty(query))
            {
                users = users.Where(u => u.Full_name.Contains(query));
            }
            int sumShops = users.Count();

            // Lấy dữ liệu của trang hiện tại
            var pagedShops = users.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewData["TotalPages"] = (int)Math.Ceiling(sumShops / (double)pageSize);
            ViewData["CurrentPage"] = page;
            ViewData["SearchQuery"] = query;
            ViewData["ItemsPerPage"] = pageSize;
            return View(pagedShops);
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> LockAccount(int id)
		{
			var user = await _context.USERS.FindAsync(id);
			if (user == null)
			{
				return NotFound();
			}

			// Change status to 1 (locked)
			user.Status = 1;
			await _context.SaveChangesAsync();

			return Redirect("/Admin/Account/AccountIndex"); 
		}

        [HttpGet("{id}")]
        public async Task<IActionResult> UnLockAccount(int id)
        {
            var user = await _context.USERS.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Change status to 1 (locked)
            user.Status = 0;
            await _context.SaveChangesAsync();

            return Redirect("/Admin/Account/AccountIndex");
        }

        public IActionResult BrowseShop(string searchQuery, string statusFilter, int page = 1, int pageSize = 2)
        {
            var shops = _context.SHOPS.AsQueryable();

            // Tìm theo tên
            if (!string.IsNullOrEmpty(searchQuery))
            {
                shops = shops.Where(s => s.Name.Contains(searchQuery));
            }

            // lọc trạng thái (duyệt là "1" or ngược lại "0")
            if (byte.TryParse(statusFilter, out byte parsedStatus))
            {
                shops = shops.Where(s => s.Status == parsedStatus);
            }
            int sumShops = shops.Count();

            // Lấy dữ liệu của trang hiện tại
            var pagedShops = shops.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewData["TotalPages"] = (int)Math.Ceiling(sumShops / (double)pageSize);
            ViewData["CurrentPage"] = page;
            ViewData["SearchQuery"] = searchQuery;
            ViewData["StatusFilter"] = statusFilter;
            return View(pagedShops);
        }

        [HttpPost]
        public IActionResult ApproveShops(List<int> selectedShops)
        {
            if (selectedShops != null && selectedShops.Any())
            {
                var shops = _context.SHOPS.Where(shop => selectedShops.Contains(shop.Id)).ToList();

                // Cập nhật trạng thái cho các nhà bán đã chọn
                foreach (var shop in shops)
                {
                    shop.Status = 1; // Đặt trạng thái thành 1 (đã duyệt)
                }

                _context.SaveChanges(); 
            }

            return Redirect("/Admin/Account/BrowseShop");
        }

        [HttpGet("{id}")]
        public IActionResult ShopDetails(int id)
        {
            var shop = _context.SHOPS
                .FirstOrDefault(s => s.Id == id);

            if (shop == null)
            {
                return NotFound();
            }

            return PartialView("DetailShop", shop);
        }

        [HttpGet("{id}")]
        public IActionResult UserDetails(int id)
        {
            var user = _context.USERS
                .FirstOrDefault(s => s.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return PartialView("DetailUser", user);
        }
    }
}
