using DATN_THELIEM_API.DATA;
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
            return _appDBContext.PRODUCTS.ToList();
        }

		public async Task<Products> GetProductById(int id)
		{
            return _appDBContext.PRODUCTS.Find(id);
        }

		
	}
}
