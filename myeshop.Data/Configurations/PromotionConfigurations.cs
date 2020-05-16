using System;
using System.Collections.Generic;
using System.Text;
using myeshop.Data.Entities;
using myeshop.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace myeshop.Data.Configurations
{
    public class PromotionConfigurations : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.ToTable("Promotions");
            builder.HasKey(x => x.Promotion_ID);
            builder.Property(x => x.Promotion_ID).UseIdentityColumn();
            builder.Property(x => x.Promotion_Name).IsRequired();
        }
    }
}
