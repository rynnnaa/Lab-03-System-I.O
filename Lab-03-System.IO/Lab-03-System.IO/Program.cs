using System;
using System.IO;

namespace SysmtemIO_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../hangmanGame.txt";
            CreateFile(path);

        }
        static void CreateFile(string path)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                Console.WriteLine("Welcome to the Guessing Game!");
                streamWriter.WriteLine("Welcome to the Guessing Game!");

            }

        }
    }
}