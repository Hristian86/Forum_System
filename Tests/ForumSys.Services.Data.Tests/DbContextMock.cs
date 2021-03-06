﻿namespace ForumSys.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using ForumSys.Data;
    using ForumSys.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class DbContextMock
    {
        private DbContextOptions<ApplicationDbContext> options;
        private ApplicationDbContext context;

        public DbContextMock()
        {
            this.options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
        }

        public ApplicationDbContext GetContext()
        {
            this.context = new ApplicationDbContext(options);
            SeedCategory(this.context);
            return this.context;
        }

        private void SeedCategory(ApplicationDbContext dbContext)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var addCategories = new List<(string Name, string ImageURL)>()
            {
                ("Programming", "https://cdn.pixabay.com/photo/2017/10/24/07/12/hacker-2883632_960_720.jpg"),
                ("Sport", "https://cdn.pixabay.com/photo/2016/09/18/14/21/swimmer-1678307_960_720.jpg"),
                ("News", "https://images.unsplash.com/photo-1585829365295-ab7cd400c167?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1350&q=80"),
                ("Music", "https://cdn.pixabay.com/photo/2016/01/19/15/07/pianist-1149172_960_720.jpg"),
                ("Animals", "https://cdn.pixabay.com/photo/2017/01/14/12/59/iceland-1979445_960_720.jpg"),
            };

            foreach (var category in addCategories)
            {
                dbContext.Categories.Add(
                    new Category
                    {
                        Name = category.Name,
                        Title = category.Name,
                        Description = category.Name,
                        ImageURL = category.ImageURL,
                    });
            }

            ApplicationUser user = new ApplicationUser()
            {
                Id = "1",
                Email = "Who knows",
                UserName = "Jhon",
            };

            this.context.Add(new Post()
            {
                CategoryId = 1,
                Title = "hello",
                Content = "hello",
                UserId = "1",
            });

            this.context.Add(new Post()
            {
                CategoryId = 1,
                Title = "hello",
                Content = "hello",
                UserId = "1",
            });

            this.context.Add(new Post()
            {
                CategoryId = 1,
                Title = "hello",
                Content = "hello",
                UserId = "1",
            });

            this.context.Add(user);

            this.context.SaveChanges();
        }
    }
}
