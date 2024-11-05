using DATN_THELIEM_API.DATA;
using DATN_THELIEM_API.IService;
using DATN_THELIEM_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DATN_THELIEM_API.Service
{
    public class ProductService : IProductService
	{
		private readonly HttpClient _httpClient;
		private readonly AppDBContext _appDBContext;

		public ProductService(HttpClient httpClient, AppDBContext appDBContext)
		{
			_httpClient = httpClient;
			_appDBContext = appDBContext;
		}

		public async Task<List<Products>> GetProducts()
		{
            return await _appDBContext.PRODUCTS
                             .Include(p => p.Categories)
                             .Include(p => p.Supplier)
                             .Include(p => p.Shops)
                             .Include(p => p.Brands)
                             .Include(p => p.Product_Variants)
                             .Include(p => p.Product_Parts)
                             .ToListAsync();
        }

		public async Task<Products> GetProductById(int id)
		{
            return await _appDBContext.PRODUCTS.Include(p => p.Categories)
                             .Include(p => p.Supplier)
                             .Include(p => p.Shops)
                             .Include(p => p.Brands)
                             .Include(p => p.Product_Variants)
                             .Include(p => p.Product_Parts)
                             .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddProduct(Products product)
        {
            await _appDBContext.PRODUCTS.AddAsync(product);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task UpdateProduct(Products product)
        {
            _appDBContext.PRODUCTS.Update(product);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _appDBContext.PRODUCTS.FindAsync(id);
            if (product != null)
            {
                product.Status = 0; // Set status to 0 instead of deleting
                _appDBContext.PRODUCTS.Update(product);
                await _appDBContext.SaveChangesAsync();
            }
        }
    }
}
