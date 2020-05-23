using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace myeshop.Data.Migrations
{
    public partial class ChangeFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Prod_ID",
                keyValue: 1,
                columns: new[] { "DateCreate", "Status" },
                values: new object[] { new DateTime(2020, 5, 23, 23, 7, 50, 999, DateTimeKind.Local).AddTicks(1827), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Prod_ID",
                keyValue: 2,
                columns: new[] { "DateCreate", "Status" },
                values: new object[] { new DateTime(2020, 5, 23, 23, 7, 51, 1, DateTimeKind.Local).AddTicks(4530), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Prod_ID",
                keyValue: 3,
                columns: new[] { "DateCreate", "Status" },
                values: new object[] { new DateTime(2020, 5, 23, 23, 7, 51, 1, DateTimeKind.Local).AddTicks(4613), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Prod_ID",
                keyValue: 4,
                columns: new[] { "DateCreate", "Status" },
                values: new object[] { new DateTime(2020, 5, 23, 23, 7, 51, 1, DateTimeKind.Local).AddTicks(4617), 1 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "967628bf-f41c-4327-bfb0-931b63e4f9a2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8dee2596-69ca-4a14-b057-08f65b56f80c", "AQAAAAEAACcQAAAAEP9KWEzvEzu/aLkc9sxG+RbdtV7TVX1D8NYlcLdcXOsfn/xPUh3um+a/QUgJT1HokQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ProductImages");

            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Prod_ID",
                keyValue: 1,
                columns: new[] { "DateCreate", "Status" },
                values: new object[] { new DateTime(2020, 5, 23, 17, 40, 45, 555, DateTimeKind.Local).AddTicks(9985), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Prod_ID",
                keyValue: 2,
                columns: new[] { "DateCreate", "Status" },
                values: new object[] { new DateTime(2020, 5, 23, 17, 40, 45, 556, DateTimeKind.Local).AddTicks(9575), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Prod_ID",
                keyValue: 3,
                columns: new[] { "DateCreate", "Status" },
                values: new object[] { new DateTime(2020, 5, 23, 17, 40, 45, 556, DateTimeKind.Local).AddTicks(9617), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Prod_ID",
                keyValue: 4,
                columns: new[] { "DateCreate", "Status" },
                values: new object[] { new DateTime(2020, 5, 23, 17, 40, 45, 556, DateTimeKind.Local).AddTicks(9620), 1 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "1ba4141e-d48e-4054-afd0-8c8998b4ac7a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c7b7b620-b183-4f7c-85d2-348473b2450d", "AQAAAAEAACcQAAAAEO/BTX7iSf+XNiKghMmrP0BMslSh4Aos7jd3NVAIHH/8pWnRWCCKJ2Xs8marzNwNfQ==" });
        }
    }
}
