using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("C:\\Users\\prive\\source\\repos\\niet belangrijk\\aoc1\\AoC-Day3\\TextFile1.txt");
            string line;
            List<char> commonCharList = new List<char>();
            List<string> allStrings = new List<string>();
            //List<int> intList = new List<int>();

            while ((line = sr.ReadLine()) != null)
            {
                //part 2, fill list with all strings
                allStrings.Add(line);
                /*
                string subStr1, subStr2;
                int strLength = line.Trim().Length;
                if (strLength % 2 != 0)
                {
                    subStr1 = line.Substring(0, (strLength / 2)+1);
                    subStr2 = line.Substring((strLength / 2) + 1, strLength / 2);
                }
                else
                {
                    subStr1 = line.Substring(0, strLength / 2);
                    subStr2 = line.Substring(strLength / 2, strLength / 2);
                }

                //add characters to a list of chars
                foreach(char c in subStr1)
                {
                    if (subStr2.Contains(c))
                    {
                        commonCharList.Add(c);
                        break;
                    }
                    
                }
                */
            }
            List<string> str1 = new List<string>();
            List<string> str2 = new List<string>();
            List<string> str3 = new List<string>();
            int index = 0;
            foreach (string s in allStrings)
            {
                int mod = index % 3;
                switch (mod)
                {
                    case 0:
                        str1.Add(s);
                        //Console.WriteLine("mod 0");
                        break;
                    case 1:
                        str2.Add(s);
                        //Console.WriteLine("mod 1");
                        break;
                    case 2:
                        str3.Add(s);
                        //Console.WriteLine("mod 2");
                        break;
                }
                index++;
            }
            int count = 0;
            //add characters to a list of chars
            foreach(string s in str1)
            {
                //add characters to a list of chars
                foreach (char ch in s)
                {
                    if (str2[count].Contains(ch) && str3[count].Contains(ch))
                    {
                        commonCharList.Add(ch);
                        break;
                    }

                }
                count++;

            }

            int sum = 0;
            foreach (char c in commonCharList)
            {
                //use ascii-value to get index
                if(c <= 95)
                {
                    //intList.Add(c - 38);
                    sum += (c - 38);
                }
                else
                {
                    //intList.Add(c - 96);
                    sum += (c - 96);
                }
                //Console.WriteLine(sum);
            }
            Console.WriteLine("som: " + sum);
            Console.ReadLine();
        }
    
    }
}
