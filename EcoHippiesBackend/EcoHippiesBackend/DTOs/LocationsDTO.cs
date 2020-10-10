using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoHippiesBackend.DTOs
{
    public class LocationsDTO
    {
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public string PathToImage { get; set; }
        public string Description { get; set; }
        public bool Cleared { get; set; }
        public virtual PostsDTO Post { get; set; }
        public virtual UsersDTO User { get; set; }
    }
}
