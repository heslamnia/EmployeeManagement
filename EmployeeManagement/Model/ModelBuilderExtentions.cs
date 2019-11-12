using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Model
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
            new Employee()
            {
                Id = 1,
                Name = "Hadi",
                Email = "hadi@gmail.com",
                Department = Dept.IT
            },
            new Employee()
            {
                Id = 2,
                Name = "ali",
                Email = "ali@gmail.com",
                Department = Dept.IT
            }
            );
        }
    }
}
