using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cochlear
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (File.Exists(args[0]))
                {
                    Numbers.parseTextFile(args[0]);
                } else
                {
                    Console.WriteLine("That file does not exist => {0}", args[1]);
                    return;
                }
            }
            else
            {
                PrintInformation();
                Numbers.DoNumbers();
            }
            
            Console.ReadKey();

        }

        private static void PrintInformation()
        {
            Console.WriteLine("This program sorts occurrences of numbers in a text-sequence");
            Console.WriteLine("If no argument is given the program will use the following text to find numbers:");
            Console.WriteLine();
            Console.WriteLine("{0}, {1}", Numbers.textString, Numbers.textString2);
            Console.WriteLine();
            Console.WriteLine("if argument is correct path to textfile, that textfile will be read.");

        }
    }
}
