using System;
using System.Collections.Generic;
using System.Text;
using myeshop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace myeshop.Data.Configurations
{
    public class ProductInSizeConfigurations : IEntityTypeConfiguration<ProductInSize>
    {
        public void Configure(EntityTypeBuilder<ProductInSize> builder)
        {
            builder.HasKey(t => new { t.Size_ID, t.Prod_ID });

            builder.ToTable("ProductInSizes");

            builder.HasOne(t => t.Product).WithMany(pc => pc.ProductInSizes)
                .HasForeignKey(pc => pc.Prod_ID);
            builder.HasOne(t => t.Size).WithMany(pc => pc.ProductInSizes)
                .HasForeignKey(pc => pc.Size_ID);
        }
    }
}
