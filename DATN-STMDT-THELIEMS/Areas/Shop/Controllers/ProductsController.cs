using DATN_STMDT_THELIEMS.DATA;
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

		public IActionResult IndexShop()
        {
			var products = _context.PRODUCTS
							  
							  .ToList();

			// Truyền dữ liệu vào View
			return View(products);
		}

		public IActionResult AddProduct() 
		{
			return View();
		}
    }
}
