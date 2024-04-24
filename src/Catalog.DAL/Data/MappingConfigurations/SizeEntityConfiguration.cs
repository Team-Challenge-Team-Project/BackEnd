using Catalog.DAL.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.Data.MappingConfigurations
{
    public class SizeEntityConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.ToTable("Size");

            builder.Property(x => x.Id)
                .IsRequired()
                .UseHiLo("size_hilo");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
