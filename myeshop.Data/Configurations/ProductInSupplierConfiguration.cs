using System;
using System.Collections.Generic;
using System.Text;
using myeshop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace myeshop.Data.Configurations
{
    public class ProductInSupplierConfiguration : IEntityTypeConfiguration<ProductInSupplier>
    {
        public void Configure(EntityTypeBuilder<ProductInSupplier> builder)
        {
            builder.HasKey(t => new { t.Supplier_ID, t.Prod_ID });

            builder.ToTable("ProductInSuppliers");

            builder.HasOne(t => t.Product).WithMany(pc => pc.ProductInSuppliers)
                .HasForeignKey(pc => pc.Prod_ID);
            builder.HasOne(t => t.Supplier).WithMany(pc => pc.ProductInSuppliers)
                .HasForeignKey(pc => pc.Supplier_ID);
        }
    }
}
