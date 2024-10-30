using DATN_STMDT_THELIEMS.DATA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DATN_STMDT_THELIEMS.Areas.Shop.Controllers
{
	[Area("Shop")]
	[Route("Shop/[controller]/[action]")]
	public class OrdersController : Controller
	{
		private readonly AppDBContext _context;

		public OrdersController(AppDBContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> OrderIndexAsync()
		{
			var orders = await _context.ORDERS
				.Include(o => o.Users)
				.Include(o => o.Shops)
				.Include(o => o.Voucher)
				.Include(o => o.Order_Details) // Include chi tiết đơn hàng
				.ToListAsync();

			return View(orders);
		}
	}
}
