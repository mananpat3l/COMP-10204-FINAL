using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    [Table(Name = "Robot")]
    public class Robot
    {
        [Column]
        public int MovieID { get; set; }
        [Column]
        public string RobotName { get; set; }
    
}
}
