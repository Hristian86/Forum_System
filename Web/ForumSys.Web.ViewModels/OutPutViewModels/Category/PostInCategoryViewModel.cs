namespace ForumSys.Web.ViewModels.OutPutViewModels.Category
{
    using System;

    using ForumSys.Data.Models;
    using ForumSys.Services.Mapping;

    public class PostInCategoryViewModel : IMapFrom<Post>
    {
        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }
    }
}
