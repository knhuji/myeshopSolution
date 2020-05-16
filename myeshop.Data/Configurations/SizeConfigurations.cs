using System;
using System.Collections.Generic;
using System.Text;
using myeshop.Data.Entities;
using myeshop.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace myeshop.Data.Configurations
{
    public class SizeConfigurations : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.ToTable("Size");
            builder.HasKey(x => x.Size_ID);
            builder.Property(x => x.Size_ID).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Status).HasDefaultValue(Status.Active);
        }
    }
}
