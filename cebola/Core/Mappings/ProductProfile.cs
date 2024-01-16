using Application.DTOs;
using AutoMapper;
using Core.Models;

namespace Core.Mappings
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			// DTO para entidade de domínio
			CreateMap<ProductDTO, Product>();

			// Entidade de domínio para DTO
			CreateMap<Product, ProductDTO>();
		}
	}
}
