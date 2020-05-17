using Microsoft.EntityFrameworkCore.Migrations;

namespace myeshop.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Supplier_ID", "Address", "Gmail", "Phone", "Status", "Supplier_Name" },
                values: new object[] { 1, "157 Trấn Hưng Đạo", "tsunstore@gmail.com", 957587411, 1, "TSUN" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Supplier_ID", "Address", "Gmail", "Phone", "Status", "Supplier_Name" },
                values: new object[] { 2, "123 Điện Biên Phủ", "badhabitstore@gmail.com", 679542147, 1, "Bad Habit" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Supplier_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Supplier_ID",
                keyValue: 2);
        }
    }
}
