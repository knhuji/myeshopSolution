using Microsoft.EntityFrameworkCore.Migrations;

namespace myeshop.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Prod_Name",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Supplier_ID",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Supplier_ID",
                keyValue: 2,
                column: "Status",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Prod_Name",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Supplier_ID",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Supplier_ID",
                keyValue: 2,
                column: "Status",
                value: 1);
        }
    }
}
