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
		public IActionResult AccountIndex(string query)
		{
            var users = _context.USERS.AsQueryable();

            if (!string.IsNullOrEmpty(query))
            {
                users = users.Where(u => u.Full_name.Contains(query));
            }

            ViewData["SearchQuery"] = query; // Pass the search query to the view
            return View(users.ToList());
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

		public IActionResult BrowseShop(string searchQuery, string statusFilter)
        {
            var shops = _context.SHOPS.AsQueryable();

            // Search by shop code
            if (!string.IsNullOrEmpty(searchQuery))
            {
                shops = shops.Where(s => s.Name.Contains(searchQuery));
            }

            // Filter by status (assuming statusFilter can be "1" or "0")
            if (byte.TryParse(statusFilter, out byte parsedStatus))
            {
                shops = shops.Where(s => s.Status == parsedStatus);
            }

            ViewData["SearchQuery"] = searchQuery;
            ViewData["StatusFilter"] = statusFilter;
            return View(shops.ToList());
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

        public IActionResult FilterShops(int? status)
        {
            var shops = _context.SHOPS.AsQueryable();

            if (status.HasValue)
            {
                shops = shops.Where(shop => shop.Status == status.Value);
            }

            var result = shops.ToList();
            return View("BrowseShop", result); // Chỉ định view "BrowseShop"
        }

        public IActionResult SearchShopsByName(string shopName)
        {
            var shops = _context.SHOPS
                .Where(s => s.Name.Contains(shopName)) // Điều kiện tìm kiếm theo tên
                .ToList();

            return View("BrowseShop", shops);
        }
    }
}
