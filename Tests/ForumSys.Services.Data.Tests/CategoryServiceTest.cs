namespace ForumSys.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSys.Data;
    using ForumSys.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CategoryServiceTest
    {
        private DbContextMock db = new DbContextMock();

        public ApplicationDbContext Context
        {
            get => this.db.GetContext();
        }

        [Fact]
        public void Category_Should_Return_All()
        {
            var data = this.Context.Categories.ToList();
            Assert.True(data.Count > 0);
        }

        [Fact]
        public void Category_Should_Return_Count()
        {
            var data = this.Context.Categories.ToList();
            Assert.True(data.Count > 1);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Category_Should_Return_Counts(int id)
        {
            var result = this.Context.Categories
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if (result == null)
            {
                throw new ArgumentNullException("Category not found");
            }

            Assert.True(result != null);
        }

        [Theory]
        [InlineData("Carss", "asdasdssssss", "Many cars")]
        public void CreateCategory(string name, string imageUrl, string description)
        {

            var newCategory = new Category
            {
                Description = description,
                ImageURL = imageUrl,
                Name = name,
                Title = name,
            };

            this.Context.Categories.Add(newCategory);
            this.Context.SaveChanges();

            var categories = this.Context.Categories.ToList();
            Assert.True(categories.Count() == 5);
        }

        public IEnumerable<Category> GetAll(int? count = null)
        {
            IQueryable<Category> query = this.Context.Categories
                .OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query;
        }
    }
}
