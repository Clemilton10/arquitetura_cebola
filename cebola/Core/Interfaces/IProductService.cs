using Core.Models;

namespace Core.Interfaces
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> GetAll();
		Task<Product>? FindById(int Id);
		Task AddProduct(Product product);
		Task UpdateProduct(Product product);
		Task DeleteProduct(int Id);
	}
}