﻿using Employee_Blazor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Employee_Blazor.DataAccess
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Cities> Cities { get; internal set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<EmployeeCourse> EmployeeCourse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeCourse>().HasKey(bc => new { bc.CourseId, bc.EmployeeId });

            modelBuilder.Entity<EmployeeCourse>()
                .HasOne(bc => bc.Courses)
                .WithMany(b => b.EmployeeCourse)
                .HasForeignKey(bc => bc.CourseId);

            modelBuilder.Entity<EmployeeCourse>()
                .HasOne(bc => bc.Employee)
                .WithMany(c => c.EmployeeCourse)
                .HasForeignKey(bc => bc.EmployeeId);

            modelBuilder.Entity<Cities>().HasData(new Cities
            {
                CityId = 1,
                CityName = "Pretoria"
            },
            new Cities
            {
                CityId = 2,
                CityName = "Johannesburg"
            });

            var EmployeeList = new List<EmployeeCourse>()
            {
                new EmployeeCourse()
                {
                    EmployeeId = 1,
                    CourseId =1
                },
                new EmployeeCourse()
                {
                    EmployeeId = 1,
                    CourseId =2
                },
                new EmployeeCourse()
                {
                    EmployeeId = 2,
                    CourseId =1
                }
            };

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Uncle",
                    LastName = "Bob",
                    Email = "uncle.bob@gmail.com",
                    DateOfBirth = new DateTime(1979, 04, 25),
                    PhoneNumber = "999-888-7777",
                    City = "Pretoria",
                    Gender = Gender.Male.ToString(),
                    Department = "IT"

                }, new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Jan",
                    LastName = "Kirsten",
                    Email = "jan.kirsten@gmail.com",
                    DateOfBirth = new DateTime(1981, 07, 13),
                    PhoneNumber = "111-222-3333",
                    City = "Johannesburg",
                    Gender = Gender.Male.ToString(),
                    Department = "Management"
                }
            );

            modelBuilder.Entity<Courses>().HasData(new Courses
            {
                CourseId = 1,
                CourseName = "Coding 101",
                Credits = 10
            },
            new Courses
            {
                CourseId = 2,
                CourseName = "Coding 201",
                Credits = 20
            });

            modelBuilder.Entity<EmployeeCourse>().HasData(EmployeeList);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MARNUS-LT;Database=EmployeeDB;Trusted_Connection=True;");
        }
    }
}
