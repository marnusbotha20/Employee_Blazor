using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_Blazor.Migrations
{
    public partial class AddedDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[,]
                {
                    { 1, "Pretoria" },
                    { 2, "Johannesburg" }
                });

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
                columns: new[] { "EmployeeId", "City", "DateOfBirth", "Department", "Email", "FirstName", "Gender", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1L, "Pretoria", new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "uncle.bob@gmail.com", "Uncle", "Male", "Bob", "999-888-7777" },
                    { 2L, "Johannesburg", new DateTime(1981, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Management", "jan.kirsten@gmail.com", "Jan", "Male", "Kirsten", "111-222-3333" }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployeeCourse",
                keyColumns: new[] { "CourseId", "EmployeeId" },
                keyValues: new object[] { 1, 1L });

            migrationBuilder.DeleteData(
                table: "EmployeeCourse",
                keyColumns: new[] { "CourseId", "EmployeeId" },
                keyValues: new object[] { 1, 2L });

            migrationBuilder.DeleteData(
                table: "EmployeeCourse",
                keyColumns: new[] { "CourseId", "EmployeeId" },
                keyValues: new object[] { 2, 1L });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2L);
        }
    }
}
