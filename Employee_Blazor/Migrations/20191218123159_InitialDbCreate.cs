using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_Blazor.Migrations
{
    public partial class InitialDbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(nullable: true),
                    Credits = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

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
                    City = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCourse",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCourse", x => new { x.CourseId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_EmployeeCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeCourse_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[,]
                {
                    { 1, "Pretoria" },
                    { 2, "Johannesburg" }
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "CompanyId", "Name" },
                values: new object[] { 1, "atWork Internet Solutions" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "Credits" },
                values: new object[,]
                {
                    { 1, "Coding 101", 10 },
                    { 2, "Coding 201", 20 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "City", "CompanyId", "DateOfBirth", "Department", "Email", "FirstName", "Gender", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1L, "Pretoria", null, new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "uncle.bob@gmail.com", "Uncle", "Male", "Bob", "999-888-7777" },
                    { 2L, "Johannesburg", null, new DateTime(1981, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Management", "jan.kirsten@gmail.com", "Jan", "Male", "Kirsten", "111-222-3333" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeCourse",
                columns: new[] { "CourseId", "EmployeeId" },
                values: new object[] { 1, 1L });

            migrationBuilder.InsertData(
                table: "EmployeeCourse",
                columns: new[] { "CourseId", "EmployeeId" },
                values: new object[] { 2, 1L });

            migrationBuilder.InsertData(
                table: "EmployeeCourse",
                columns: new[] { "CourseId", "EmployeeId" },
                values: new object[] { 1, 2L });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCourse_EmployeeId",
                table: "EmployeeCourse",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "EmployeeCourse");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
