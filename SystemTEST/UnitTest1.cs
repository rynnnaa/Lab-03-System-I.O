using System;
using Xunit;
using System_IO;
using System.IO;

namespace SystemTEST
{
    public class UnitTest1
    {
        [Fact]
        public void AddWordWorks()
        {
            //arrange
            string path = "../../../hangman.txt";
            string userAdd = "flower";
            //act
            string index = Program.Add(path, userAdd);

            //assert
            Assert.Contains("flower", userAdd);

        }

        [Fact]
        public void ViewAllWordsWorks()
        {
            //arrange
            string path = "../../../hangmanGame.txt";

            //act
            string index = Program.ViewAll(path);

            //assert
            Assert.Equal("DOG", index);
        }

        [Fact]
        public void DeleteWordWorks()
        {
            ////arrange
            string path = "../hangmanGame.txt";
            string useradd = "daisy";
            string index = Program.Add(path, useradd);

            string[] wordsInFile = File.ReadAllLines(path);
            string userDelete = "daisy";

            //act
            Program.DeleteWord(path, userDelete);

            string[] newA = File.ReadAllLines(path);
            //assert
            Assert.DoesNotContain(userDelete, newA);

        }
        
            [Fact]
            public void TestUpdateWord()
            {
                string update = "UPDATE";
                string[] expectedResult = { "minus", "plus", "equals", "UPDATE" };
                Assert.Equal(expectedResult, Program.Add(update));
            }
        }
}
