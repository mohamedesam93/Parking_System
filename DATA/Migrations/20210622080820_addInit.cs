using Microsoft.EntityFrameworkCore.Migrations;

namespace DATA.Migrations
{
    public partial class addInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "SkyWay" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CarId", "Name", "Position" },
                values: new object[] { 1, 21, null, "Mohamed", "Dev" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Name" },
                values: new object[] { 1, 1, "ccdVideoCamera" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CardId", "ModelId", "OwnerId", "PlateNumber" },
                values: new object[] { 1, null, 1, 1, "أدد" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
