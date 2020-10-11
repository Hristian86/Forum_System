namespace ForumSys.Web.ViewModels.OutPutViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PostCreateInputModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }
    }
}
