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

    public class CommentServiceTest
    {
        private DbContextMock db = new DbContextMock();

        public ApplicationDbContext Context
        {
            get => this.db.GetContext();
        }

        [Theory]
        [InlineData(14, "1", "Who knows", "Idkasd asd as")]
        [InlineData(11, "1", "Who knows", "Idkasd asd as")]
        [InlineData(33, "1", "Who knows", "Idkasd asd as")]
        public async Task Should_Not_Save_Comment(int postId, string userId, string content, string title)
        {
            try
            {
                int id = await CreateComment(postId, userId, content, title);
                int id2 = await CreateComment(postId, userId, content, title);
                int id3 = await CreateComment(postId, userId, content, title);
                int id4 = await CreateComment(postId, userId, content, title);
            }
            catch (Exception ex)
            {
                Assert.True(ex.Message != null);
            }
        }

        [Theory]
        [InlineData(1, "1", "Who knows", "Idkasd asd as")]
        public async Task Should_Save_Comment(int postId, string userId, string content, string title)
        {
            int id = await CreateComment(postId, userId, content, title);
            int id2 = await CreateComment(postId, userId, content, title);
            int id3 = await CreateComment(postId, userId, content, title);
            int id4 = await CreateComment(postId, userId, content, title);

            Assert.True(id == 1);
            Assert.True(id2 == 2);
            Assert.True(id3 == 3);
            Assert.True(id4 == 4);
        }

        public async Task<int> CreateComment(int postId, string userId, string content, string title)
        {
            var exists = this.Context.Posts.Any(x => x.Id == postId);
            if (!exists)
            {
                throw new ArgumentException("Post id is not found");
            }

            if (content == null || content.Length < 5)
            {
                throw new ArgumentException("Content must be at least 5 symbols");
            }
            else if (content.Length > 15000)
            {
                throw new ArgumentException("Content must be under 15000 symbols");
            }

            if (userId == null)
            {
                throw new ArgumentNullException("User is required");
            }

            var comment = new Comment()
            {
                Content = content,
                PostId = postId,
                UserId = userId,
                Title = title,
            };

            this.Context.Add(comment);
            await this.Context.SaveChangesAsync();
            return comment.Id;
        }
    }
}
