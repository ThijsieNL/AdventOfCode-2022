using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AoC_Day8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("C:\\Users\\prive\\source\\repos\\niet belangrijk\\aoc1\\AoC-Day8\\TextFile1.txt");

            int width = 100;
            int height = 99;

            (int, bool)[,] trees = new (int, bool)[height, width];
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                int lineIndex = 0;
                //initialise data.
                for(int i = 0; i < width; i++)
                {
                    int toAdd = line[i];
                    trees[lineIndex, i] = (toAdd, false);
                }
            }
            //check if the tree sizes are ascending, and if we see a tree, set it to true so we don't add it again to the counter
            //check for north, east, south, and west. 
            int total = 494;
            int notHiddenTrees = 0;
            for(int i = 0; i < width; i++)
            {
                int lineIndex = 1;
                int checklayer = 1;
                while (trees[lineIndex, i].Item1 < trees[lineIndex + checklayer, i].Item1)
                {
                    trees[lineIndex, i].Item2 = true;
                    trees[lineIndex + checklayer, i].Item2 = true;
                    checklayer++;
                }

            }
        }
    }
}
