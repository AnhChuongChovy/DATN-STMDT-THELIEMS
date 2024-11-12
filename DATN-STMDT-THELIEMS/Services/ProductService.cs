using DATN_STMDT_THELIEMS.DATA;
using DATN_STMDT_THELIEMS.Models;
using Microsoft.EntityFrameworkCore;

namespace DATN_STMDT_THELIEMS.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDBContext _context;

        public ProductService(AppDBContext context)
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
                .Include(p => p.product_Attributes)
                    .ThenInclude(a => a.Attributes)
                    .ThenInclude(a => a.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Products>> GetSimilarProductsAsync(int productId, int categoryId, int limit = 20)
        {
            return await _context.PRODUCTS
                .Where(p => p.Id != productId && p.Category_id == categoryId)
                .OrderBy(p => Guid.NewGuid())
                .Take(limit)
                .ToListAsync();
        }

        public async Task<List<Products>> GetDiscountedProductsAsync(int limit = 20)
        {
            return await _context.PRODUCTS
                .Where(p => p.Percent_Decrease.HasValue && p.Percent_Decrease > 0)
                .OrderByDescending(p => p.Percent_Decrease)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<List<Products>> GetBestSellingProductsAsync(int limit = 20)
        {
            return await _context.PRODUCTS
                .Where(p => p.Sold_count.HasValue)
                .OrderByDescending(p => p.Sold_count)
                .Take(limit)
                .ToListAsync();
        }

    }
}
