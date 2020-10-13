namespace ForumSys.Web.ViewModels.OutPutViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ForumSys.Data.Models;
    using ForumSys.Services.Mapping;
    using Ganss.XSS;

    public class PostViewModel : IMapFrom<Post>
    {
        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitazeContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }
    }
}
