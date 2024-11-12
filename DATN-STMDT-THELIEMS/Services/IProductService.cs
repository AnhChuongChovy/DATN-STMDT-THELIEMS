using DATN_STMDT_THELIEMS.Models;

namespace DATN_STMDT_THELIEMS.Services
{
    public interface IProductService
    {
        Task<Products> GetProductsByIdAsync(int id);
        Task<List<Products>> GetSimilarProductsAsync(int productId, int categoryId, int limit = 20);
        Task<List<Products>> GetDiscountedProductsAsync(int limit = 20);
        Task<List<Products>> GetBestSellingProductsAsync(int limit = 20);

    }
}
