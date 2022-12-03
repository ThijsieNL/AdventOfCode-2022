using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> calories = new List<int>();
            
            int currentCount = 0;
            int check = 0;
            int index = 0;
            StreamReader sr = new StreamReader("C:\\Users\\prive\\source\\repos\\niet belangrijk\\aoc1\\aoc1\\TextFile1.txt");
            string p = sr.ReadToEnd();
            string[] lines = p.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            //sum numbers that are not separated by a white line
            foreach (string line in lines)
            {
                //if not empty, add to the current count
                if (line.Trim() != "")
                {
                    currentCount += int.Parse(line);
                }
                else
                {
                    //push current to list of calories, and reset current
                    calories.Add(currentCount);
                    currentCount = 0;
                }
            }
            //find the 3 highest elements
            foreach (int i in calories)
            {
                if (i > check)
                {
                    check = i;
                    index = calories.IndexOf(i);
                }
            }
            int p1 = check;
            calories.RemoveAt(index);
            check = 0;
            foreach (int i in calories)
            {
                if (i > check)
                {
                    check = i;
                    index = calories.IndexOf(i);
                }
            }
            int p2 = check;
            calories.RemoveAt(index);
            check = 0;
            foreach (int i in calories)
            {
                if (i > check)
                {
                    check = i;
                    index = calories.IndexOf(i);
                }
            }
            int p3 = check;
            Console.WriteLine(p1 + p2 + p3);

            Console.ReadLine();

        }
    }
}
