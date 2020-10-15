namespace ForumSys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using ForumSys.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public string UserId { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        public VoteType Type { get; set; }
    }
}
