using System;
using System.Collections.Generic;
using System.Text;
using myeshop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using myeshop.Data.Enums;

namespace myeshop.Data.Configurations 
{
    public class TransactionConfigurations : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(x => x.Transaction_ID);

            builder.Property(x => x.Transaction_ID).UseIdentityColumn();

            builder.HasOne(x => x.User).WithMany(x => x.Transactions).HasForeignKey(x => x.UserId);
        }
    }
}
