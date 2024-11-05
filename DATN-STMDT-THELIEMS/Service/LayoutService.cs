//using DATN_STMDT_THELIEMS.Models;
//using DATN_STMDT_THELIEMS.DATA;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Mvc;
//using DATN_STMDT_THELIEMS.Service;
//public class LayoutService : ILayoutSerivce
//    {
//        private readonly AppDBContext _context;

//        public LayoutService(AppDBContext context)
//        {
//            _context = context;
//        }

//        // phương thức cho thanh Tìm kiếm để show sp 
//        public async Task<List<Product>> SearchProductsByNameAsync(string query)
//        {
//            return await _context.Products
//                .Where(p => p.Name.Contains(query))
//                .ToListAsync();
//        }
//    }
//}
