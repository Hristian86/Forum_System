namespace ForumSys.Web.ViewModels.OutPutViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Web.Mvc;

    public class PostCreateInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        [AllowHtml]
        public string Content { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }
    }
}
