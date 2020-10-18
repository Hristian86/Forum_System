namespace ForumSys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ForumSys.Data.Common.Repositories;
    using ForumSys.Data.Models;
    using ForumSys.Services.Mapping;

    public class PostService : IPostService
    {
        private readonly IDeletableEntityRepository<Post> postRepository;

        public PostService(IDeletableEntityRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
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

            await this.postRepository.AddAsync(post);
            await this.postRepository.SaveChangesAsync();
            return post.Id;
        }

        public T GetById<T>(int id)
        {
            var post = this.postRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            if (post == null)
            {
                throw new ArgumentNullException("The post is not found");
            }

            return post;
        }

        public IEnumerable<T> GetByCategoryId<T>(int categoryID, int? take = null, int skip = 0)
        {
            IQueryable<Post> querey = this.postRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Where(x => x.CategoryId == categoryID)
                .Skip(skip);
            if (take.HasValue)
            {
                querey = querey.Take(take.Value);
            }

            return querey.To<T>().ToList();
        }
    }
}
