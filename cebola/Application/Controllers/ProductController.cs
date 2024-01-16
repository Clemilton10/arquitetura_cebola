using Application.DTOs;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace arq_cebola.Application.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductController(IProductService produtoService, IMapper mapper)
		{
			_productService = produtoService;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			var products = await _productService.GetAll();
			//var productsDTO = _mapper.Map<IEnumerable<ProductDTO>>(products);
			return View(products);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(ProductDTO productDTO)
		{
			// Mapear DTO para entidade de domínio se necessário
			var p = new Product
			{
				Name = productDTO.Name,
				Price = productDTO.Price
			};

			await _productService.AddProduct(p);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Update(int Id)
		{
			var p = await _productService.FindById(Id);
			return View(p);
		}

		[HttpPost("{Id}")]
		public async Task<IActionResult> UpdateProduct(int Id, Product product)
		{
			var p = new Product
			{
				Id = Id,
				Name = product.Name,
				Price = product.Price
			};
			await _productService.UpdateProduct(p);
			return RedirectToAction("Index");
		}
	}
}
