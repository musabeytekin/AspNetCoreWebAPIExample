﻿using System;
namespace NLayer.Core.DTOs
{
	public class ProductCreateDto
	{
        public int Id { get; set; }
        public DateTime CreatedDate = DateTime.Now;
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}

