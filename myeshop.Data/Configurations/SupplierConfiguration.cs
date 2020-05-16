using System;
using myeshop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using myeshop.Data.Enums;
using System.Collections.Generic;
using System.Text;

namespace myeshop.Data.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");
            builder.HasKey(x => x.Supplier_ID);
            builder.Property(x => x.Supplier_ID).UseIdentityColumn();
            builder.Property(x => x.Supplier_Name).IsRequired();
            builder.Property(x => x.Gmail).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.Status).HasDefaultValue(Status.Active);
        }
    }
}
