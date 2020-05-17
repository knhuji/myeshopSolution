using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using myeshop.Data.Entities;
using myeshop.Data.Enums;

namespace myeshop.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier()
                {
                    Supplier_ID = 1,
                    Supplier_Name = "TSUN",
                    Gmail = "tsunstore@gmail.com",
                    Address = "157 Trấn Hưng Đạo",
                    Phone = 0957587411,
                    Status = Status.Active
                },

                new Supplier()
                {
                    Supplier_ID = 2,
                    Supplier_Name = "Bad Habit",
                    Gmail = "badhabitstore@gmail.com",
                    Address = "123 Điện Biên Phủ",
                    Phone = 0679542147,
                    Status = Status.Active
                }
            );
        }
    }
}
