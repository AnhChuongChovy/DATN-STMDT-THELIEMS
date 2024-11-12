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
        private readonly IHomeService _homeService;

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

        public  IActionResult ShopView()
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

        public async Task<IActionResult> Pay(int productId, int quantity, int price, string image, string color, string size)
        {
            var product = await _productService.GetProductsByIdAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            var order = new Checkout
            {
                Product = product,
                Quantity = quantity,
                Price = price, 
                Image = image, 
                TotalPrice = price,
                Color = color,
                Size = size
            };

            return View(order);
        }

        public async Task<IActionResult> ProductDetails(int id)
        {
            var products = await _productService.GetProductsByIdAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            // Lấy sản phẩm tương tự
            var similarProducts = await _productService.GetSimilarProductsAsync(id, products.Category_id.GetValueOrDefault());
            ViewBag.SimilarProducts = similarProducts;

            // Lấy sản phẩm đang giảm giá
            var discountedProducts = await _productService.GetDiscountedProductsAsync();
            ViewBag.DiscountedProducts = discountedProducts;

            // Lấy sản phẩm bán chạy
            var bestSellingProducts = await _productService.GetBestSellingProductsAsync();
            ViewBag.BestSellingProducts = bestSellingProducts;

            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
