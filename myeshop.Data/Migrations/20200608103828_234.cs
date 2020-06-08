using System;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Migrations;

namespace myeshop.Data.Migrations
{
    public partial class _234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Prod_ID",
                keyValue: 1,
                columns: new[] { "DateCreate", "Status" },
                values: new object[] { new DateTime(2020, 6, 8, 17, 38, 28, 90, DateTimeKind.Local).AddTicks(7110), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Prod_ID",
                keyValue: 2,
                columns: new[] { "DateCreate", "Status" },
                values: new object[] { new DateTime(2020, 6, 8, 17, 38, 28, 92, DateTimeKind.Local).AddTicks(697), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Prod_ID",
                keyValue: 3,
                columns: new[] { "DateCreate", "Status" },
                values: new object[] { new DateTime(2020, 6, 8, 17, 38, 28, 92, DateTimeKind.Local).AddTicks(739), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Prod_ID",
                keyValue: 4,
                columns: new[] { "DateCreate", "Status" },
                values: new object[] { new DateTime(2020, 6, 8, 17, 38, 28, 92, DateTimeKind.Local).AddTicks(743), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Prod_ID",
                keyValue: 5,
                columns: new[] { "DateCreate", "Status" },
                values: new object[] { new DateTime(2020, 6, 8, 17, 38, 28, 92, DateTimeKind.Local).AddTicks(746), 1 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "56fbeda2-4818-4942-95b7-f069ae8ffbd9");

            migrationBuilder.AddColumn<String>(
                name: "Description",
                table: "Products"
                );

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "af7eeb42-32f4-4184-ba2b-228b53d03377", "AQAAAAEAACcQAAAAEFxn3fabcWVQPuSCoXQ7QGsfF26eVj3mOzSyyeMOrcXhcHOi1IPvR7VYcUvUU6qPhA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Prod_ID",
                keyValue: 1,
                columns: new[] { "DateCreate", "Status" },
                values: new object[] { new DateTime(2020, 6, 8, 17, 34, 42, 680, DateTimeKind.Local).AddTicks(4666), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Prod_ID",
                keyValue: 2,
                columns: new[] { "DateCreate", "Status" },
                values: new object[] { new DateTime(2020, 6, 8, 17, 34, 42, 682, DateTimeKind.Local).AddTicks(3186), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Prod_ID",
                keyValue: 3,
                columns: new[] { "DateCreate", "Status" },
                values: new object[] { new DateTime(2020, 6, 8, 17, 34, 42, 682, DateTimeKind.Local).AddTicks(3248), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Prod_ID",
                keyValue: 4,
                columns: new[] { "DateCreate", "Status" },
                values: new object[] { new DateTime(2020, 6, 8, 17, 34, 42, 682, DateTimeKind.Local).AddTicks(3253), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Prod_ID",
                keyValue: 5,
                columns: new[] { "DateCreate", "Status" },
                values: new object[] { new DateTime(2020, 6, 8, 17, 34, 42, 682, DateTimeKind.Local).AddTicks(3256), 1 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "1cdee820-5bff-4cd4-887c-478fe86c1de8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4867cb93-8769-4e16-a721-36d18cfbaf74", "AQAAAAEAACcQAAAAEBNOwQJCDdLwDm5L17tbpK+2BD7TbO9tgcRowI41mmrZm2Vejksm2rd7MTSJB3V7Eg==" });
        }
    }
}
