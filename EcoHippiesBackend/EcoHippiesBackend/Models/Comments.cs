using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcoHippiesBackend.Models
{
    public class Comments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      
        public int CommentId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UserId { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Replies> Replies { get; set; }

    }
}
