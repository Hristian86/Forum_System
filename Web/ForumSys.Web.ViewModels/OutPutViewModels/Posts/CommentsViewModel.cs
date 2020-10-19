namespace ForumSys.Web.ViewModels.OutPutViewModels.Posts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ForumSys.Data.Models;
    using ForumSys.Services.Mapping;
    using Ganss.XSS;

    public class CommentsViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public string SenitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }
    }
}
