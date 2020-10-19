namespace ForumSys.Web.ViewModels.OutPutViewModels.Comments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CommentsInputModel
    {
        public int PostId { get; set; }

        public string Content { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        public string UserId { get; set; }
    }
}
