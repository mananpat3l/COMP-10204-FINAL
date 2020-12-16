using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    [Table(Name = "Movie")]
    public class Movie
    {
        [Column]
        public int MovieID { get; set; }
        [Column]
        public string Title { get; set; }
        [Column]
        public string Director { get; set; }
        [Column]
        public int ReleaseYear{ get; set; }
        [Column]
        public int Runtime { get; set; }
        

    }
}
