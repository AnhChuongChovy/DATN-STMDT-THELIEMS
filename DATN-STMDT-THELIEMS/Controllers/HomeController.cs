using DATN_STMDT_THELIEMS.DATA;
using DATN_STMDT_THELIEMS.Models;
using DATN_STMDT_THELIEMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DATN_STMDT_THELIEMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShopView()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult ShopCart()
        {
            return View();
        }

        public IActionResult UserInfo()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Pay()
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
