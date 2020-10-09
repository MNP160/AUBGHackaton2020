using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcoHippiesBackend.Models
{
    public class Replies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReplyId { get; set; }
        public string Message { get; set; }
        public DateTime RepliedOn { get; set; }
        public int? CommentId { get; set; }
        public virtual Comments Comment { get; set; }
        public int? UserId { get; set; }
        public virtual Users User { get; set; }
    }
}
