using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* A = rock, X = 3, Y = 6, Z = 0
             * B = paper X = 0, Y = 3, Z = 6
             * C = scissors X = 6, Y = 0, Z = 3
             * counteractions and points
             * X = rock (playing gives 1 pts)
             * Y = paper (playing gives 2 pts)
             * Z = scissors (playing gives 3 pts)
             * scores per outcome: 
             * losing = 0
             * draw = 3
             * winning = 6
            */

            StreamReader sr = new StreamReader("C:\\Users\\prive\\source\\repos\\niet belangrijk\\aoc1\\AoC2\\TextFile1.txt");
            int turnScore = 0;
            int totalScore = 0;
            int part2Total = 0;
            string line;
            string p = sr.ReadToEnd();
            string[] lines = p.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string s in lines)
            {
                int resultScore = 0;
                int moveValue = 0;
                if(s == "")
                {
                    break;
                }
                //Console.WriteLine("turnscore:" + turnScore);
                switch (s[0])
                {
                    case 'A': //enemy rock
                        switch (s[2])
                        {
                            case 'X':
                                moveValue = 1;
                                turnScore = 3;
                                part2Total += 3;
                                break;
                            case 'Y':
                                moveValue = 2;
                                turnScore = 6;
                                part2Total += 4;
                                break;
                            case 'Z':
                                moveValue = 3;
                                turnScore = 0;
                                part2Total += 8;
                                break;
                        }
                        break;
                    case 'B': //enemy paper
                        switch (s[2])
                        {
                            case 'X':
                                moveValue = 1;
                                turnScore = 0;
                                part2Total += 1;
                                break;
                            case 'Y':
                                moveValue = 2;
                                turnScore = 3;
                                part2Total += 5;
                                break;
                            case 'Z':
                                moveValue = 3;
                                turnScore = 6;
                                part2Total += 9;
                                break;
                        }
                        //Console.WriteLine(turnScore);
                        break;
                    case 'C': //enemy 
                        switch (s[2])
                        {
                            case 'X':
                                moveValue = 1;
                                turnScore = 6;
                                part2Total += 2;
                                break;
                            case 'Y':
                                moveValue = 2;
                                turnScore = 0;
                                part2Total += 6;
                                break;
                            case 'Z':
                                moveValue = 3;
                                turnScore = 3;
                                part2Total += 7;
                                break;
                        }
                        //Console.WriteLine(turnScore);
                        break;
                    
                }
                //add movevalue
                totalScore += moveValue;
                //Console.WriteLine("total:"+totalScore);
                totalScore += turnScore;
                turnScore = 0;
            }
            Console.WriteLine("part2: " + part2Total);
            //Console.WriteLine("eind:"+totalScore);
            Console.ReadLine();


        }
    }
}
