using Core.Interfaces;
using Core.Models;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class ProductRepository : IProductService
	{
		private readonly AppDbContext _dbContext;

		public ProductRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<Product>> GetAll()
		{
			return await _dbContext.Products.ToListAsync();
		}

		public async Task<Product>? FindById(int Id)
		{
			return await _dbContext.Products.FindAsync(Id);
		}

		public async Task AddProduct(Product product)
		{
			_dbContext.Products.Add(product);
			await _dbContext.SaveChangesAsync();
		}

		public async Task UpdateProduct(Product product)
		{
			var p = _dbContext.Products.Find(product.Id);
			if (p != null)
			{
				p.Name = product.Name;
				p.Price = product.Price;
				_dbContext.Entry(p).State = EntityState.Modified;
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task DeleteProduct(int Id)
		{
			var p = _dbContext.Products.Find(Id);
			if (p != null)
			{
				_dbContext.Remove(p);
				await _dbContext.SaveChangesAsync();
			}
		}
	}
}

