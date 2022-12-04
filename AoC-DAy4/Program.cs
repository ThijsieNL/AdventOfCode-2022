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
            //Console.WriteLine("part 1: " + part1(sr));
            Console.WriteLine("part 2: " + part2(sr));
            Console.ReadLine();
        }
        public static int part2(StreamReader sr)
        {
            string line;
            int count = 0;
            while ((line = sr.ReadLine()) != null)
            {
                string[] ranges = line.Split(',');
                int r1Low = int.Parse(ranges[0].Split('-')[0]);
                int r1High = int.Parse(ranges[0].Split('-')[1]);
                int r2Low = int.Parse(ranges[1].Split('-')[0]);
                int r2High = int.Parse(ranges[1].Split('-')[1]);
                bool check1 = (r1Low <= r2Low && r2Low <= r1High);
                bool check2 = (r2Low <= r1Low && r1Low <= r2High);
                if ( check1 || check2)
                {
                    count++;
                }
            }
            return count;
        }
        public static int part1(StreamReader sr)
        {
            string line;
            int count = 0;
            while ((line = sr.ReadLine()) != null)
            {
                string[] ranges = line.Split(',');
                int r1Low = int.Parse(ranges[0].Split('-')[0]);
                int r1High = int.Parse(ranges[0].Split('-')[1]);
                int r2Low = int.Parse(ranges[1].Split('-')[0]);
                int r2High = int.Parse(ranges[1].Split('-')[1]);
                bool check1 = r1Low <= r2Low && r1High >= r2High;
                bool check2 = r2Low <= r1Low && r2High >= r1High;
                if (check1 || check2)
                {
                    count++;
                }   
            }
            return count;
        }
    }
}
