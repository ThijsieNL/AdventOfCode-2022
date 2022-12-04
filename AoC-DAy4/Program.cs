using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_DAy4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("C:\\Users\\prive\\source\\repos\\niet belangrijk\\aoc1\\AoC-Day4\\TextFile1.txt");
            Console.WriteLine("part 1: " + part1(sr));
            Console.ReadLine();
        }
        public static int part1(StreamReader s)
        {
            string line;
            int count = 0;
            while ((line = s.ReadLine()) != null)
            {
                string[] ranges = line.Split(',');
                int range1Low = int.Parse(ranges[0].Split('-')[0]);
                int range1High = int.Parse(ranges[0].Split('-')[1]);
                int range2Low = int.Parse(ranges[1].Split('-')[0]);
                int range2High = int.Parse(ranges[1].Split('-')[1]);
                if ((range1Low <= range2Low && range1High >= range2High) || (range2Low <= range1Low && range2High >= range1High))
                {
                    count++;
                }

            }
            return count;
        }
    }
}
