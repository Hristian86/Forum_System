namespace ForumSys.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ForumSys.Data;
    using ForumSys.Data.Models;
    using Xunit;

    public class PostServiceTest
    {
        private DbContextMock db = new DbContextMock();

        public ApplicationDbContext Context
        {
            get => this.db.GetContext();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task Should_Get_Post_By_Id(int id)
        {
            var result = GetById(id);
            Assert.True(result != null);
        }

        [Fact]
        public async Task Should_Create_Post()
        {
            int id4 = await CreateAsync("hello", "How are you", 1, "1");
            int id5= await CreateAsync("hello", "How are you", 3, "1");
            int id6 = await CreateAsync("hello", "How are you", 2, "1");

            // Pre created 3 posts in the in memory database.
            Assert.True(id4 == 4);
            Assert.True(id5 == 5);
            Assert.True(id6 == 6);
        }

        [Theory]
        [InlineData(1)]
        public void Should_Get_By_Category_id(int categoryId)
        {
            var result = GetByCategoryId(categoryId);

            Assert.True(result.Count() == 3);
            Assert.True(result != null);
        }

        [Theory]
        [InlineData(2)]
        public void Should_Not_Get_By_Category_id(int categoryId)
        {
            var result = GetByCategoryId(categoryId);

            Assert.True(result.Count() == 0);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(22)]
        [InlineData(55)]
        public async Task Should_Not_Create_Post(int categoryId)
        {
            var currentCount = this.Context.Posts.Count();
            Assert.True(currentCount == 3);

            int id = await CreateAsync("hello", "How are you", categoryId, "1");
            var result = this.Context.Posts.ToList();
            Assert.True(result.Count() == 3);
        }

        public Post GetById(int id)
        {
            var post = this.Context.Posts.Where(x => x.Id == id).FirstOrDefault();
            if (post == null)
            {
                throw new ArgumentNullException("The post is not found");
            }

            return post;
        }

        public async Task<int> CreateAsync(string title, string content, int categoryId, string userId)
        {
            Post post = new Post()
            {
                CategoryId = categoryId,
                Title = title,
                Content = content,
                UserId = userId,
            };

            this.Context.Add(post);
            await this.Context.SaveChangesAsync();
            return post.Id;
        }

        public IEnumerable<Post> GetByCategoryId(int categoryID, int? take = null, int skip = 0)
        {
            IQueryable<Post> query = this.Context.Posts
                .OrderByDescending(x => x.CreatedOn)
                .Where(x => x.CategoryId == categoryID)
                .Skip(skip);
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.ToList();
        }
    }
}
