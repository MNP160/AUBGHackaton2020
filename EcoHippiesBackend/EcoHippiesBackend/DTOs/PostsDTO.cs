using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoHippiesBackend.DTOs
{
    public class PostsDTO
    {
        public string Title { get; set; }
        public int LocationId { get; set; }
        public virtual LocationsDTO Location { get; set; }
        public virtual ICollection<CommentsDTO> Comments { get; set; }
    }
}
