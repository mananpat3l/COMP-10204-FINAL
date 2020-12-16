using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    [Table(Name = "Alien")]
    public class Alien
    {
        [Column]
        public int MovieID { get; set; }
        [Column]
        public string AlienName { get; set; }

    }
}