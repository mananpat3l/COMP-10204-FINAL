using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    [Table(Name = "Planet")]
    public class Planet
    {
        [Column]
        public int MovieID { get; set; }
        [Column]
        public string PlanetName { get; set; }
    }
}
