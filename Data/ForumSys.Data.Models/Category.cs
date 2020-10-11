namespace ForumSys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using ForumSys.Data.Common.Models;

    // not real delete
    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Posts = new HashSet<Post>();
        }

        [MaxLength(100)]
        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
