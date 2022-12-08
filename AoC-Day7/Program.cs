using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /// read input, make directories depending on what we read.
            /// if we encounter a `$ ls`, look at what is the current directory (thus we need to keep track of our current dir)
            /// then keep reading and adding elements until the first character of line == $
            /// if we encounter a number, add it to that directory's list of fileSizes. 
            /// if we encounter a directory, add a directory

            // a list of linkedlists of directories? we need to keep track of every directory that is in another dir,
            // thus we need to be able to keep track of every dir's parent and their list of children
            // every 'previous' is the parent of a dir, but we need the possibility to have several nexts
            // --> a tree structure of dirs where the amount of children is unknown.
            //  --> when we encounter a `$ cd ..` we go up to the parent of that node (dir), and we identify nodes by their char


            // how move through a tree
            StreamReader sr = new StreamReader("C:\\Users\\prive\\source\\repos\\niet belangrijk\\aoc1\\AoC-Day7\\TextFile1.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                // when given a new directory, add it to the tree
                if (line.StartsWith("$ ls"))
                {
                    //the previous cd shows which directory we are in. 
                    //read until the next $
                    // keep adding children to the current directory - or filesize list
                    
                }
                if (line.StartsWith("$ cd .."))
                {
                    //move up a directory, thus make current directory equal to the parent.
                    

                }
                //this means that we change to a lower directory.
                else if (line.Split(' ')[0] + line.Split(' ')[1] == "$ cd")
                {
                    
                }
            }

        }
        
        
    }
    public class dir
    {
        public List<int> fileSizes = new List<int>();
        public List<dir> directories = new List<dir>();
        public dir parent; //this will be initialised when we reach this dir in 
        public string id; //this is the character of the directory
        public int dirSize;

        public dir(List<int> sizes, List<dir> dirs, string id, dir parent)
        {
            this.fileSizes = sizes;
            this.directories = dirs;
            this.id = id;
            this.parent = parent;
            //this.dirSize = this.getFileSizes(this);
        }

        //getfilesizes method that produces an int. 
        public int getFileSizes(dir dir)
        {
            int total = 0;
            foreach(int i in dir.fileSizes)
            { 
                total += i;
            }
            foreach(dir d in dir.directories)
            {
                //add the lists of the directory recursively
                int dSize = d.getFileSizes(d);

                total += d.getFileSizes(d);
            }
            return total;
        }

    }
}
