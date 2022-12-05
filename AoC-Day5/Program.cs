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
            for(int i = 0; i<9; i++)
            {
                //initialise the stacks in the list
                stackList.Add(new Stack<char>());
            }
            //read file
            string line;
            //!sr.endofline
            while ((line = sr.ReadLine()) != null)
            {
                if(line == " ")
                {
                    partOfStream++;
                    continue;
                }
                if (partOfStream == 1)
                {
                    int index = 1;
                    //stackindex makes it clear to which stack to push the letter
                    int stackindex = 0;
                    //deze loop zorgt ervoor dat je dezelfde line blijft lezen, dit leest de characters
                    while (index < line.Length)
                    {
                        if (line[index] >= 65 || line[index] <= 90)
                        {
                            //Console.WriteLine(line[index]);
                            //push character to the list of chars
                            //NOTE: THIS GIVES A REVERSE STACK, WE NEED TO REVERSE EACH STACK IN THE ARRAY
                            stackList[stackindex].Push(line[index]);
                        }
                        stackindex += 1;
                        index += 4;
                    }
                }
                if(partOfStream == 2)
                {
                    Console.WriteLine("reversed");
                    //reversedStackList = reverseStacks(stackList);
                    partOfStream++;
                }
                if (partOfStream == 3)
                {
                    //read the moves
                    string[] moves = line.Split(' ');
                    for(int i = 0;  i<moves.Length; i++)
                    {
                        Console.WriteLine(moves[i]);
                    }
                    int amount = int.Parse(moves[1]);
                    //TODO: don't use - 1 for the index? make sure that the process goes correctly, step by step
                    int startindex = int.Parse(moves[3]) - 1;
                    int endindex = int.Parse(moves[5]) - 1;
                    makeMove(stackList, amount, startindex, endindex);
                    //makeMove(reversedStackList, amount, startindex, endindex);
                }
                
            }
            Console.WriteLine("done");
            List<char> charResultList = new List<char>();
            foreach (Stack<char> stack in stackList)
            {
                //Console.Write(stack.Pop());
                //charResultList.Add(stack.Peek());
                foreach (char c in stack)
                {
                    Console.WriteLine(c);
                }
                Console.WriteLine("");
                
            }
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
            return reversedList;
        }
    }
}
