using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoHippiesBackend.DTOs
{
    public class RepliesDTO
    {
        public string Message { get; set; }
        public DateTime RepliedOn { get; set; }
        public int UserId { get; set; }
    }
}
