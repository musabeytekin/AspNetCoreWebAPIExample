using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public ProductSeed()
        {
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product() { Id = 1, CategoryId = 1, Name = "Pen 1", Price = 100, Stock = 20, CreatedDate = DateTime.Now },
                new Product() { Id = 2, CategoryId = 1, Name = "Pen 2", Price = 100, Stock = 20, CreatedDate = DateTime.Now },
                new Product() { Id = 3, CategoryId = 1, Name = "Pen 3", Price = 100, Stock = 20, CreatedDate = DateTime.Now },
                new Product() { Id = 4, CategoryId = 2, Name = "Book 1", Price = 100, Stock = 20, CreatedDate = DateTime.Now },
                new Product() { Id = 5, CategoryId = 2, Name = "Book 2", Price = 100, Stock = 20, CreatedDate = DateTime.Now }
            );
        }
    }
}

