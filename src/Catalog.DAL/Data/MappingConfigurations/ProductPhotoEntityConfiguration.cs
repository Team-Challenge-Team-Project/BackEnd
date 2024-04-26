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
    public class ProductPhotoEntityConfiguration : IEntityTypeConfiguration<ProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductPhoto> builder)
        {
            builder.ToTable("ProductPhoto");

            builder.Property(x => x.Id)
                .UseHiLo("photo_hilo")
                .IsRequired();

            builder.Property(x => x.Source)
                .IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductPhotos)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
