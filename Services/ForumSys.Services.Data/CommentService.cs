namespace ForumSys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ForumSys.Data.Common.Repositories;
    using ForumSys.Data.Models;

    public class CommentService : ICommentService
    {
        private readonly IDeletableEntityRepository<Comment> commentRepository;
        private readonly IPostService postService;

        public CommentService(
            IDeletableEntityRepository<Comment> commentRepository,
            IPostService postService)
        {
            this.commentRepository = commentRepository;
            this.postService = postService;
        }

        public async Task CreateComment(int postId, string userId, string content, string title)
        {
            var exists = this.postService.PostExists(postId);
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

            await this.commentRepository.AddAsync(comment);
            await this.commentRepository.SaveChangesAsync();
        }
    }
}
