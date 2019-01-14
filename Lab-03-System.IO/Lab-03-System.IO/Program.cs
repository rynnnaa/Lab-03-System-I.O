using System;
using System.IO;

namespace SysmtemIO_demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = "../../../hangmanGame.txt";
            CreateFile(path);
            GameMenuUI(path);

        }
        public static void CreateFile(string path)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                Console.WriteLine("Welcome to the Guessing Game!");
                streamWriter.WriteLine("Welcome to the Guessing Game!");

            }

        }
        public static void GameMenuUI(string path)
        {
            bool playingGame = true;

            while (playingGame)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1: View all words");
                Console.WriteLine("2: Add a word");
                Console.WriteLine("3: Delete a word");
                Console.WriteLine("4: Play Game");
                Console.WriteLine("5: Exit");
                try
                {
                    string selectedOption = Console.ReadLine();
                    selected = Convert.ToInt32(selectedOption);

                    

                }
            }
        }    
    }
}