using AutoMapper;
using Core.DTOs;
using Core.Models;

namespace Core.Mappings
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			// DTO para entidade de domínio
			CreateMap<ProductDTO, Product>().ReverseMap();
			// isso vai os dois serviços
		}
	}
}
