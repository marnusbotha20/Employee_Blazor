using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_Blazor.Migrations
{
    public partial class AddedDepartmentCityToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "City", "DateOfBirth", "Department", "Email", "FirstName", "Gender", "LastName", "PhoneNumber" },
                values: new object[] { 1L, null, new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "uncle.bob@gmail.com", "Uncle", null, "Bob", "999-888-7777" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "City", "DateOfBirth", "Department", "Email", "FirstName", "Gender", "LastName", "PhoneNumber" },
                values: new object[] { 2L, null, new DateTime(1981, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "jan.kirsten@gmail.com", "Jan", null, "Kirsten", "111-222-3333" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
