using DATN_THELIEM_API.Models;

namespace DATN_THELIEM_API.IService
{
    public interface IProductService
    {
        Task<List<Products>> GetProducts();
        Task<Products> GetProductById(int id);
        Task AddProduct(Products product);
        Task UpdateProduct(Products product);
        Task DeleteProduct(int id);
    }
}
