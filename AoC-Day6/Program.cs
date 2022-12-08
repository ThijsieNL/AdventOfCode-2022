using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("C:\\Users\\prive\\source\\repos\\niet belangrijk\\aoc1\\AoC-Day6\\TextFile1.txt");
            int currentIndex = 0;
            int arrsize = 14;
            int[] arr = new int[arrsize];
            string input = sr.ReadLine();
            //get the first 4 elements of the string in the array
            for (int i = 0; i < arrsize; i++)
            {
                arr[i] = input[i];
            }

            for (int i = 0; i < input.Length; i++)
            {
                //we replace the element at the current index with the new element
                
                //we check if all elements are different
                if (CheckIfAllDifferent(arr))
                {
                    //if they are, we return the index
                    Console.WriteLine("index = " + currentIndex);
                    break;
                }
                arr[currentIndex % arrsize] = input[i];
                //if they aren't, we continue
                currentIndex++;
            }

            Console.ReadLine();
        }
        public static bool CheckIfAllDifferent(int[] arr)
        {
            //we check if all elements are different
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (i != j)
                    {
                        if (arr[i] == arr[j])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
