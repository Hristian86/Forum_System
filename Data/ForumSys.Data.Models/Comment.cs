﻿namespace ForumSys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using ForumSys.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public int PostId { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        public virtual Post Post { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
