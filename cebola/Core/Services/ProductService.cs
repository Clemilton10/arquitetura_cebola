using Core.Interfaces;
using Core.Models;
using Infrastructure.Repositories;

namespace Core.Services
{
	public class ProductService : IProductService
	{
		private readonly ProductRepository _productRepository;

		public ProductService(ProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<IEnumerable<Product>> GetAll()
		{
			return await _productRepository.GetAll();
		}

		public async Task<Product>? FindById(int id)
		{
			return await _productRepository.FindById(id);
		}

		public async Task AddProduct(Product product)
		{
			await _productRepository.AddProduct(product);
		}

		public async Task UpdateProduct(Product product)
		{
			await _productRepository.UpdateProduct(product);
		}
	}
}