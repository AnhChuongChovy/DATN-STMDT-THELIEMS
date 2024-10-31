using DATN_STMDT_THELIEMS.DATA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
				.Include(o => o.Order_Details)
					.ThenInclude(od => od.Product_variants)
						.ThenInclude(pv => pv.Product_Variant_Options) // Thêm Include cho product_variant_option
							.ThenInclude(pvo => pvo.variant_values) // Thêm Include cho variant_values
								.ThenInclude(vv => vv.Variant_Options) // Thêm Include cho variant_option
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

		[HttpGet("{orderId}")]
        [Route("{orderId}")]
        public async Task<IActionResult> OrderDetail(int orderId)
		{
			var order = await _context.ORDERS
		.Include(u => u.Users)
		.Include(p => p.Order_Details)
			.ThenInclude(p => p.Product_variants)
			.ThenInclude(o => o.Product_Variant_Options)
			.ThenInclude(o => o.variant_values)
			.ThenInclude(o => o.Variant_Options)
		.FirstOrDefaultAsync(p => p.Id == orderId);

			if (order == null || order.Order_Details == null || !order.Order_Details.Any())
			{
				return NotFound(); // or display an appropriate message in the view
			}
			
			return View(order);
		}
	}
}
