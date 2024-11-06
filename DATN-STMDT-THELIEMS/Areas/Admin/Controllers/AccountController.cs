using DATN_STMDT_THELIEMS.DATA;
using DATN_STMDT_THELIEMS.Models;
using Microsoft.AspNetCore.Mvc;

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
		public IActionResult AccountIndex()
		{
			var user = _context.USERS.ToList();
			return View(user);
		}

        public IActionResult BrowseShop()
        {
            var user = _context.SHOPS.ToList();
            return View(user);
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

                _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }

            return Redirect("/Admin/Account/BrowseShop"); // Quay lại trang hiện tại sau khi duyệt
        }

      
	}
}
