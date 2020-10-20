namespace ForumSys.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class IpAddress
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [MaxLength(50)]
        public string Ip { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
