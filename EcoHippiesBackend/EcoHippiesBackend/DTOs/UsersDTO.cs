using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoHippiesBackend.DTOs
{
    public class UsersDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public virtual ICollection<CommentsDTO> Comments { get; set; }
       
        public virtual ICollection<LocationsDTO> Locations { get; set; }
    }
}
