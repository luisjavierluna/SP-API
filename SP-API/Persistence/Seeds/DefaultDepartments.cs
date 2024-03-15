using Domain.Entities;
using Persistence.Context;
using System;

namespace Persistence.Seeds
{
    public class DefaultDepartments
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            for (int i = 0; i < 100; i++)
            {
                Department department = new Department
                {
                    Name = $"Department{i + 1}",
                    Description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Facere voluptatibus inventore nobis aliquam ipsam molestiae quasi repellendus, laboriosam aspernatur autem quis dolorem officiis, modi totam placeat porro! Officiis, quis quo! lore"
                };

                var departments = context.Departments.Select(x => x.Name).ToList();

                if (!departments.Contains(department.Name))
                {
                    context.Departments.Add(department);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
