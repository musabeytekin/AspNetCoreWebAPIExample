using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Seeds
{
    public class ProductFeatureSeed : IEntityTypeConfiguration<ProductFeature>
    {
        public ProductFeatureSeed()
        {
        }

        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasData(
                new ProductFeature() { Id = 1, Color = "Red", Height = 100, Width = 200, ProductId = 1 },
                new ProductFeature() { Id = 2, Color = "Blue", Height = 100, Width = 200, ProductId = 2 }
            );
        }
    }
}