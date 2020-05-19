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
            modelBuilder.Entity<Product>().HasData(

                new Product()
                {
                    Prod_ID = 1,
                    Prod_Name = 1,
                    DateCreate = DateTime.Now,
                    Price = 200000,
                    Quantity = 10,
                    Status = Status.Active,

                }
            );

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

            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "maithiphuongth@gmail.com",
                NormalizedEmail = "maithiphuongth@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                FirstName = "Phuong",
                LastName = "Phuong",
                Dob = new DateTime(2020, 01, 31)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Prod_ID = 1,
                    Prod_Name = "DDU-183 -TROPICAL POCKET",
                    Price = 300000,
                    Quantity = 2,
                    DateCreate = DateTime.Now,
                    Description = "Áo tay ngắn xuất xứ Hàn Quốc",
                    Status = Status.Active
                },
                new Product()
                {
                    Prod_ID = 2,
                    Prod_Name = "Sweatshirt Madonna and Child",
                    Price = 450000,
                    Quantity = 1,
                    DateCreate = DateTime.Now,
                    Description = "Vivarini",
                    Status = Status.Active
                },
                new Product()
                {
                    Prod_ID = 3,
                    Prod_Name = "CYPERNETIC ANGEL T-SHIRT",
                    Price = 320000,
                    Quantity = 1,
                    DateCreate = DateTime.Now,
                    Description = "Chất liệu: 100% cotton Made in Việt Nam",
                    Status = Status.Active
                },
                new Product()
                {
                    Prod_ID = 4,
                    Prod_Name = "ANGRY JUNGLE T-SHIRT",
                    Price = 320000,
                    Quantity = 2,
                    DateCreate = DateTime.Now,
                    Description = "Chất liệu: 100% cotton Made in Việt Nam",
                    Status = Status.Active
                }
            );
            modelBuilder.Entity<ProductInSupplier>().HasData(
                new ProductInSupplier() 
                { 
                    Prod_ID = 1,
                    Supplier_ID = 1
                },
                new ProductInSupplier()
                {
                    Prod_ID = 2,
                    Supplier_ID = 1
                },
                new ProductInSupplier()
                {
                    Prod_ID = 3,
                    Supplier_ID = 2
                },
                new ProductInSupplier()
                {
                    Prod_ID = 4,
                    Supplier_ID = 2
                }
            );
        }
    }
}
