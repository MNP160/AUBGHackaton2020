using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcoHippiesBackend.Models
{
    public class Locations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public string PathToImage { get; set; }
        public string Description { get; set; }
        public bool Cleared { get; set; }
        public virtual Posts Post { get; set; }
        public int? UserId { get; set; }
        public virtual Users User { get; set; }

    }
}
