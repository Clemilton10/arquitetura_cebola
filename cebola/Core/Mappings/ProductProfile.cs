using Application.DTOs;
using AutoMapper;
using Core.Models;

namespace Core.Mappings
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			// DTO para entidade de dom�nio
			CreateMap<ProductDTO, Product>();

			// Entidade de dom�nio para DTO
			CreateMap<Product, ProductDTO>();
		}
	}
}
