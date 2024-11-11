using DATN_STMDT_THELIEMS.DATA;
using DATN_STMDT_THELIEMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DATN_STMDT_THELIEMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class ReviewController : Controller
	{
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly AppDBContext _context;

		public ReviewController(AppDBContext context, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_webHostEnvironment = webHostEnvironment;
		}
        [HttpGet]
        public IActionResult ListReviews()
        {
            // Query to fetch reviews for a specific product, including user info
            var reviewsQuery = _context.PRODUCT_REVIEWS
                                .Include(r => r.User)
                                .Include(r => r.Order_details)
                                .ThenInclude(o =>o.Product_variants)
                                .ThenInclude(p=>p.Products)
                                .Include(r=>r.Review_Medias)
                                .AsQueryable();

            return View(reviewsQuery);
        }


    }
}
