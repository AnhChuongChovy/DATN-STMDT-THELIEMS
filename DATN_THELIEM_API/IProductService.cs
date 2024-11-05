using DATN_THELIEM_API.Models;

namespace DATN_THELIEM_API
{
	public interface IProductService
	{
		Task<List<Products>> GetProducts();
		Task<Products> GetProductById(int id);
	}
}
