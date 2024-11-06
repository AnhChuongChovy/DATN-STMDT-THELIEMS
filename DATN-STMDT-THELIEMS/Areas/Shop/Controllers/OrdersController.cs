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
		public async Task<IActionResult> OrderIndex()
		{
			var orders = await _context.ORDERS
				.Include(o => o.Users) 
				.Include(o => o.Shops) 
				.Include(o => o.Voucher) 
				.Include(o => o.Order_Details) 
					.ThenInclude(od => od.Product_variants)
						.ThenInclude(pv => pv.Products) 
				.ToListAsync();

			return View(orders);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateStatusOrder(int orderId)
		{
			var order = await _context.ORDERS.FindAsync(orderId);
			if (order == null)
			{
				return NotFound();
			}

			// Cập nhật trạng thái thành "chờ lấy hàng"
			order.Status = 1; // "2" là trạng thái "chờ lấy hàng"
			_context.ORDERS.Update(order);
			await _context.SaveChangesAsync();

			return RedirectToAction("OrderIndex", "Orders", new { area = "Shop" }); 
		}

		[HttpPost]
		public async Task<IActionResult> CancelOrder(int orderId)
		{
			var order = await _context.ORDERS.FindAsync(orderId);
			if (order == null)
			{
				return NotFound();
			}

			// Cập nhật trạng thái thành "chờ lấy hàng"
			order.Status = 2; // "2" là trạng thái "chờ lấy hàng"
			_context.ORDERS.Update(order);
			await _context.SaveChangesAsync();

			return RedirectToAction("OrderIndex", "Orders", new { area = "Shop" });
		}
	}
}
