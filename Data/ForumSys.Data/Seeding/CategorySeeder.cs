namespace ForumSys.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ForumSys.Data.Models;

    public class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var addCategories = new List<string>()
            {
                "Programing",
                "Sport",
                "News",
                "Music",
                "Animals",
            };

            foreach (var category in addCategories)
            {
                await dbContext.Categories.AddAsync(
                    new Category
                    {
                        Name = category,
                        Title = category,
                        Description = category,
                    });
            }
        }
    }
}
