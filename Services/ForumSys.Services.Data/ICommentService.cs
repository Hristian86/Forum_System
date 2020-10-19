namespace ForumSys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICommentService
    {
        Task CreateComment(int postId, string userId, string content, string title);
    }
}
