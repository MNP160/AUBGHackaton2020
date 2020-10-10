using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoHippiesBackend.DTOs
{
    public class CommentsDTO
    {
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<RepliesDTO> Replies { get; set; }
    }
}
