using DATN_STMDT_THELIEMS.Models;
using DATN_STMDT_THELIEMS.DATA;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DATN_STMDT_THELIEMS.Services;
using DATN_STMDT_THELIEMS.Service;

namespace DATN_STMDT_THELIEMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService, IProductService productService)
        {
            _logger = logger;
            _homeService = homeService;
            _productService = productService;


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
        public IActionResult CategoryHomeView()
        {
            return View();
        }
        public async Task<IActionResult> ProductDetails(int id)
        {
            var products = await _productService.GetProductsByIdAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
