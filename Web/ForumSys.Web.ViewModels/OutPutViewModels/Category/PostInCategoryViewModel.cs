namespace ForumSys.Web.ViewModels.OutPutViewModels.Category
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;

    using ForumSys.Data.Models;
    using ForumSys.Services.Mapping;

    public class PostInCategoryViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public int VotesCount { get; set; }

        public string ShortContent
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
                return content.Length > 260 ? content.Substring(0, 260) + "...." : content;
            }
        }

        public int PostsCount { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }

        public IEnumerable<Vote> Votes { get; set; }

        public int PositiveVotes
        {
            get => this.Votes.Where(x => x.Type == VoteType.UpVote).Count();
        }

        public int NegativeVotes
        {
            get => this.Votes.Where(x => x.Type == VoteType.DownVote).Count();
        }
    }
}
