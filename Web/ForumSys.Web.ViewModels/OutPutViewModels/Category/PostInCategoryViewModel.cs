namespace ForumSys.Web.ViewModels.OutPutViewModels.Category
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    using ForumSys.Data.Models;
    using ForumSys.Services.Mapping;

    public class PostInCategoryViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string ShortContent
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
                return content.Length > 260 ? content.Substring(0, 260) + "...." : content;
            }
        }

        public string Content { get; set; }

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }
    }
}
