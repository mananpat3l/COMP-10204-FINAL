using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PartA
{
    //I, Manan Patel, 000826892 certify that this material is my original work.  No other person's work has been used without due acknowledgement.

    public class Program
    {
        static void Main(string[] args)
        {
            int min = 0;
            Queue<Car> car1 = new Queue<Car>();
            Queue<Car> car2 = new Queue<Car>();
            Random ran = new Random();
            int booth1 = 0;
            int booth2 = 0;
            while (min != 60)
            {
                Thread.Sleep(1000);
                if (ran.Next(2,5)==3)
                {
                    car1.Enqueue(new Car());

                }
                if (ran.Next(2,5) == 3)
                {
                    car2.Enqueue(new Car());

                }
                if (car1.Count != 0)
                {
                    if (booth1 == car1.Peek().TimeLeft)
                    {
                        car1.Dequeue();
                        booth1 = 0;
                    }
                    else
                    {
                        
                        booth1 += 1;
                    }
                }
                if (car2.Count != 0)
                {
                    if (booth2 == car2.Peek().TimeLeft)
                    {
                        car2.Dequeue();
                        booth2 = 0;
                    }
                    else
                    {
                        booth2 += 1;

                    }
                }
                Console.WriteLine($"At minute {min}:");
                min += 1;
                if (car1.Count != 0)
                {
                    Console.WriteLine($"\t1: Booth1 Queued :{car1.Peek().Number}( {car1.Count()})");

                }
                if (car2.Count != 0)
                {
                    Console.WriteLine($"\t2: Booth2: Queued : {car2.Peek().Number}({car2.Count()})");

                }
            }
        }
    }
}

