using System;
using System.IO;

namespace System_IO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = "../hangmanGame.txt";
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

                    if (selected == 1 || selected == 2 || selected == 3 || selected == 4 || selected == 5) ;
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
                                break;
                            case 4:
                                break;


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

        public static string DeleteWord(string path, string userDelete)
        {
            try
            {
                if (userDelete.Length > 0)
                {
                    string[] wordsInFile = File.ReadAllLines(path);
                    foreach (string word in wordsInFile)
                    {
                        //check if delete word rwuest equals a word in list, and ignores differences in case
                        if (string.Equals(word, userDelete, StringComparison.CurrentCultureIgnoreCase))
                        {
                            //the new list of words without deleted word
                            string[] newFileList = new string[wordsInFile.Length - 1];
                            int counter = 0;
                            for (int i = 0; i < newFileList.Length; i++)
                            {
                                if (userDelete == wordsInFile[counter])
                                {
                                    i--;
                                    counter++;
                                }
                                else
                                {
                                    newFileList[i] = wordsInFile[counter];
                                    counter++;
                                }
                            }
                            //this send the new list of words to the txt file
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
    }

}