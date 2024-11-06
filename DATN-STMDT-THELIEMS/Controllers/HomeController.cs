using DATN_STMDT_THELIEMS.Models;
using DATN_STMDT_THELIEMS.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DATN_STMDT_THELIEMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;

        }

        [HttpGet]
		public async Task<IActionResult> Index()
		{
			// Call the service to get the list of products
			var products = await _homeService.GetAllProducts();
			return View(products);
		}
		public IActionResult ShopView()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
