using System.Collections.Generic;
using System.Linq;
using DATN_STMDT_THELIEMS.Models;
using DATN_STMDT_THELIEMS.DATA;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DATN_STMDT_THELIEMS.Service;

namespace DATN_STMDT_THELIEMS.Services
{
    public class HomeService : IHomeService
    {
        private readonly AppDBContext _context;

        public HomeService (AppDBContext context)
        {
            _context = context;
        }

        // phương thức đổ dữ liệu tất cả sp
         
        public async Task<IEnumerable< Products>> GetAllProducts()
        {
            return await _context.PRODUCTS.ToListAsync();
                
        }


         
    }
}
