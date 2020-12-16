using System;
using System.Collections.Generic;
using System.Text;

namespace PartA
{
    public class Car
    {
        public int Number { get; private set; }
        public int TimeLeft { get; set; }
        private static Random r = new Random();
        private static int count = 0;

        public Car()
        {
            Number = 2000 + count++;           //Unique car ID
            TimeLeft = r.Next(4) + 2;          //Wait 2 to 5 minutes
        }

        public override string ToString()
        {
            return string.Format($"{Number}({TimeLeft})");
        }
    }
}
