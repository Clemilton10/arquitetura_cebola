global using Xunit;
using arq_cebola.Application.Controllers;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace cebola.teste
{
	public class UnitTest1
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public UnitTest1(IProductService produtoService, IMapper mapper)
		{
			_productService = produtoService;
			_mapper = mapper;
		}

		[Fact]
		public void HomeController_Index_ReturnsViewResult()
		{
			// Arrange
			var controller = new HomeController();

			// Act
			var result = controller.Index();

			// Assert
			Assert.IsType<ViewResult>(result);
		}
		[Fact]
		public void ProductController_Index_ReturnsViewResult()
		{
			try
			{
				// Arrange
				var controller = new ProductController(_productService, _mapper);

				// Act
				var result = controller.Index();

				// Assert
				Assert.IsType<ViewResult>(result);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		//[Fact]
		//public async Task ProductService_FindById_ReturnsCorrectProduct()
		//{
		//	// Arrange
		//	var mockRepo = new Mock<ProductRepository>();
		//	var testProduct = new Product { Id = 1, Name = "Test" };
		//	mockRepo.Setup(repo => repo.FindById(1)).ReturnsAsync(testProduct);
		//	var productService = new ProductService(mockRepo.Object);

		//	// Act
		//	var product = await productService.FindById(1);

		//	// Assert
		//	Assert.Equal(1, product.Id);
		//}
	}
}