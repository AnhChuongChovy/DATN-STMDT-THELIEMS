using DATN_STMDT_THELIEMS.Models;

namespace DATN_STMDT_THELIEMS.Services
{
    public interface IProductService
    {
        Task<Products> GetProductsByIdAsync(int id);
    }
}
