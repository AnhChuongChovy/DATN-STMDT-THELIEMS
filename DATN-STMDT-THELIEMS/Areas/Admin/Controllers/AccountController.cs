using DATN_STMDT_THELIEMS.DATA;
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
	}
}
