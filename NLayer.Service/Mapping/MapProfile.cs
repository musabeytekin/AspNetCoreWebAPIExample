﻿using System;
using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;

namespace NLayer.Service.Mapping
{
	public class MapProfile : Profile
	{
		public MapProfile()
		{
			CreateMap<Product, ProductDto>().ReverseMap();
			CreateMap<ProductUpdateDto, Product>();
			CreateMap<Category, CategoryDto>().ReverseMap();
			CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
		}
	}
}

