using DATN_STMDT_THELIEMS.DATA;
using DATN_STMDT_THELIEMS.Models;
using Microsoft.EntityFrameworkCore;

namespace DATN_STMDT_THELIEMS.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDBContext _context;

        public ProductService (AppDBContext context)
        {
            _context = context;
        }

        public async Task<Products> GetProductsByIdAsync(int id)
        {
            return await _context.PRODUCTS
                .Include(p => p.Brands)
                .Include(p => p.Product_Variants)
                    .ThenInclude(v => v.Product_Images)
                .Include(p => p.Product_Variants)
                    .ThenInclude(v => v.Product_Variant_Options)
                        .ThenInclude(o => o.variant_values)
                        .ThenInclude(i => i.Variant_Options)
                .Include(p => p.Product_Parts)
                    .ThenInclude(pp => pp.Product_Part_Images)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
