using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("C:\\Users\\prive\\source\\repos\\niet belangrijk\\aoc1\\AoC-Day5\\TextFile1.txt");
            List<Stack<char>> stackList = new List<Stack<char>>();
            List<Stack<char>> reversedStackList = new List<Stack<char>>();
            int partOfStream = 1;
            //maak de stacks
            for(int i = 0; i < 9; i++)
            {
                //initialise the stacks in the list
                stackList.Add(new Stack<char>());
                reversedStackList.Add(new Stack<char>());
            }

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                //Console.WriteLine(partOfStream);
                if (line == " ")
                {
                    partOfStream++;
                    continue;
                }
                //read the stacks
                if (partOfStream == 1)
                {
                    int index = 1;
                    int stackindex = 0;

                    //deze loop zorgt ervoor dat je dezelfde line blijft lezen, dit leest de characters
                    while (index < line.Length)
                    {
                        if (line[index] >= 65 && line[index] <= 90)
                        {
                            stackList[stackindex].Push(line[index]);
                        }
                        stackindex += 1;
                        index += 4;
                    }
                    Console.WriteLine("stacklist 1: " + stackList[0].Count);
                }
                //this happens when the string is only a space == " "
                if(partOfStream == 2)
                {
                    reversedStackList = reverseStacks(stackList);

                    partOfStream++;
                }
                
                //do the moves
                if (partOfStream == 3)
                {
                    //read the moves
                    string[] moves = line.Split(' ');
                    int amount = int.Parse(moves[1]);
                    int startindex = int.Parse(moves[3]) - 1; //need the - 1 for indexing...
                    int endindex = int.Parse(moves[5]) - 1;

                    //this actually moves around the elements of the stack.
                    for (int i = 0; i < amount; i++)
                    {
                        char popped = reversedStackList[startindex].Pop();
                        reversedStackList[endindex].Push(popped);
                    }
                }
                
            }
            Console.WriteLine("testing the answer: ");
            List<char> charResultList = new List<char>();
            foreach (Stack<char> stack in reversedStackList)
            {
                Console.WriteLine("popped:" + stack.Peek());
                foreach (char c in stack)
                {
                    Console.WriteLine("char = " + c);
                }
                charResultList.Add(stack.Peek());
            }
            Console.WriteLine("result: ");
            foreach (char c in charResultList)
            {
                Console.Write(c);
            }
            Console.WriteLine("\ndone");
            
            //Console.WriteLine(reversedStackList[0].Pop());
            Console.ReadLine();
        }
        public static List<Stack<char>> makeMove(List<Stack<char>> list, int amount, int startindex, int endindex)
        {
            //stop alle characters in een queue die je popt, en vervolges stop je die weer op een stack op endindex
            //push the characters to the stack on place endindex
            for (int i = 0; i < amount; i++)
            {
                char popped = list[startindex].Pop();
                list[endindex].Push(popped);
            }
            //return the newly formed list
            return list;
        }
        public static List<Stack<char>> reverseStacks(List<Stack<char>> list)
        {   
            List<Stack<char>> reversedList = new List<Stack<char>>();
            foreach (Stack<char> stack in list)
            {
                Stack<char> reversedStack = new Stack<char>();
                while (stack.Count > 0)
                {
                    reversedStack.Push(stack.Pop());
                }
                reversedList.Add(reversedStack);
            }
            //remove white space in the stack
            foreach (Stack<char> stack in reversedList)
            {
                while (stack.Peek() == ' ')
                {
                    stack.Pop();
                }
            }
            return reversedList;
        }
    }
}
