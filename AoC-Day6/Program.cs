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
            //goal: find first index where we have 4 different characters in the queue;
            //use a queue. OR a 4-index array, we add the elementsby using mod 4
            //we use an int index to keep track of the position we are in the string
            /* [0,1,2,3] <- here we swap the new character with arr[index % 4]
             * ^^ TEST IF THIS WORKS, because that would make implementing this much easier i think 
             * setup: 
             * > first get the first 4 elements of the string in the array at their respective places.
             * > make sure we can traverse a string and that the replacing goes the way it should
             * > if we have that set, we can make a method that takes an array, and produces a bool whether or not all elements are different 
             *   from eachother
             * > if they are, return index, if they aren't, continue what we were doing
             */
            int currentIndex = 0;
            int arrsize = 14;
            int[] arr = new int[arrsize];
            string input = sr.ReadLine();
            //get the first 4 elements of the string in the array
            for (int i = 0; i < arrsize; i++)
            {
                arr[i] = input[i];
            }
            //now we have the first 4 elements in the array, we can start traversing the string
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

            //Console.WriteLine(input);
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
