﻿using System;
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
                    int selected = Convert.ToInt32(selectedOption);

                    if (selected == 1 || selected == 2 || selected == 3 || selected == 4 || selected == 5);
                    {
                        switch (selected)
                        {
                            case 1:
                                ViewAll(path);
                                break;
                            case 2:
                                Console.WriteLine("What word do you want to add?");
                                string addWord = Console.ReadLine().ToUpper();
                                Add(path, addWord);
                                break;
                            case 3:
                                DeleteWord(path);

                        }
                    }
                }

                catch
                {
                    Console.WriteLine("Please choose from option Menu");
                }
            }
        }  
        public static string ViewAll(string path)
        {
            string[] lines = File.ReadAllLines(path);
                try
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        Console.WriteLine(lines[i]);
                    }
                }

                catch (Exception e)
                {
                throw e;
            }
            Console.WriteLine(lines[0]);
            return lines[0];
        }

        public static string Add(string path, string addWord)
        {
            try
            {
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    streamWriter.WriteLine(addWord);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return addWord;
        }

        public static string DeleteWord(string path)
        {
            try
            {
                if (userDelete.Length > 0)
                {
                    string[] wordsInTxt = File.ReadAllLines(path);
                    foreach (string word in wordsInTxt)
                    {

                        if (string.Equals(word, userDelete, StringComparison.CurrentCultureIgnoreCase))
                        {
                            //show new list minus deleted word
                            string[] newFileList = new string[wordsInTxt.Length - 1];
                            int counter = 0;
                            for (int i = 0; i < newFileList.Length; i++)
                            {
                                if (userDelete == wordsInTxt[counter])
                                {
                                    i--;
                                    counter++;
                                }
                                else
                                {
                                    newFileList[i] = wordsInTxt[counter];
                                    counter++;
                                }
                            }
                            // send the list of words to txt file
                            using (StreamWriter streamWriter = new StreamWriter(path))
                            {
                                for (int i = 0; i < newFileList.Length; i++)
                                {
                                    streamWriter.WriteLine(newFileList[i]);
                                }
                            }
                            Console.WriteLine($"{userDelete} Deleted.");

                        }

                    }
                    Console.WriteLine($"{userDelete} does not exist");

                }
                else
                {
                    throw new Exception("Please enter word to be deleted.");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Try again");
            }
            return userDelete;
        }

        /// <summary>
        /// View all the words in the txt file
        /// </summary>
        /// <param name="path">location of file</param>

        public static string GetRandomWord(string path)
        {
            try
            {   //gets random word from array of words
                string[] lines = File.ReadAllLines(path);
                Random line = new Random();
                int index = line.Next(lines.Length);
                return lines[index];
            }
            catch (Exception e)
            {
                throw e;

            }
        }
    }
}