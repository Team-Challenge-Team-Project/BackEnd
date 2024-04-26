using Catalog.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.Data.MappingConfigurations
{
    public class ProductVariantEntityConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.ToTable("ProductVariant");

            builder.Property(x => x.Id)
                .UseHiLo("variant_hilo")
                .IsRequired();

            builder.Property(x => x.Quantity).IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductVariants)
                .HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Size)
                .WithMany()
                .HasForeignKey(x => x.SizeId);
            
        }
    }
}
