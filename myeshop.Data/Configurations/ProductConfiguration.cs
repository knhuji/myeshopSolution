using System;
using myeshop.Data.Entities;
using myeshop.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;

namespace myeshop.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Prod_ID);
            builder.Property(x => x.Prod_ID).UseIdentityColumn();
            builder.Property(x => x.Prod_Name).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Status).HasDefaultValue(Status.Active);
            builder.Property(x => x.Description).IsRequired();
        }
    }
}
