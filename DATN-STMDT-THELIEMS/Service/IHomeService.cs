using DATN_STMDT_THELIEMS.Models;

namespace DATN_STMDT_THELIEMS.Service
{
    public interface IHomeService 
    {
        Task<IEnumerable<Products>> GetAllProducts();
    }
}
