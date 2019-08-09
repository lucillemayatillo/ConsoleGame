using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            while (!done)
            {
                Console.Clear();

                Console.WriteLine("Let's play Hangman!");

                Console.WriteLine("Enter a word: ");
                string secretWord = Console.ReadLine();

                //make sure only letters is entered
                bool wordTest = secretWord.All(Char.IsLetter);

                while (wordTest == false || secretWord.Length == 0)
                {
                    Console.WriteLine("A word must contain (only) letters");
                    Console.Write("Please enter a word: ");
                    secretWord = Console.ReadLine();
                    wordTest = secretWord.All(Char.IsLetter);
                }

                secretWord = secretWord.ToUpper();
                Console.Clear();

                //Console.Clear not working in Repl.it
                //using this hide the secret word
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                          "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                          "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

                int lives = 5;
                int counter = -1;
                int wordLength = secretWord.Length;
                char[] secretArray = secretWord.ToCharArray();
                char[] printArray = new char[wordLength];
                char[] guessedLetters = new char[26];
                int numberStore = 0;
                bool victory = false;
                string printGuessedLetters = String.Empty;

                foreach (char letter in printArray)
                {
                    counter++;
                    printArray[counter] = '-';
                }

                while (lives > 0)
                {
                    counter = -1;
                    string printProgress = String.Concat(printArray);
                    printGuessedLetters = String.Concat(guessedLetters);
                    bool letterFound = false;
                    int multiples = 0;

                    if (printProgress == secretWord)
                    {
                        victory = true;
                        break;
                    }

                    if (lives > 1)
                    {
                        Console.WriteLine("You have {0} lives!", lives);
                    }
                    else
                    {
                        Console.WriteLine("You only have {0} live left!!", lives);
                    }

                    Console.WriteLine("current progress: " + printProgress);
                    Console.WriteLine("guessed letters: " + printGuessedLetters);
                    Console.Write("\n\n\n");
                    Console.Write("Guess a letter: ");
                    string playerGuess = Console.ReadLine();

                    //make sure a single letter is entered
                    bool guessTest = playerGuess.All(Char.IsLetter);

                    while (guessTest == false || playerGuess.Length != 1)
                    {
                        Console.WriteLine("Please enter only a single letter!");
                        Console.Write("Guess a letter: ");
                        playerGuess = Console.ReadLine();
                        guessTest = playerGuess.All(Char.IsLetter);
                    }

                    playerGuess = playerGuess.ToUpper();
                    char playerChar = Convert.ToChar(playerGuess);

                    if (guessedLetters.Contains(playerChar) == false)
                    {
                        guessedLetters[numberStore] = playerChar;
                        numberStore++;

                        foreach (char letter in secretArray)
                        {
                            counter++;
                            if (letter == playerChar)
                            {
                                printArray[counter] = playerChar;
                                letterFound = true;
                                multiples++;
                            }
                        }

                        if (letterFound)
                        {
                            Console.WriteLine("Found {0} letter {1}!", multiples, playerChar);
                        }
                        else
                        {
                            Console.WriteLine("No letter {0}!", playerChar);
                            lives--;
                        }
                        Console.WriteLine(GallowView(lives));
                    }
                    else
                    {
                        Console.WriteLine("You already guessed {0}!!", playerChar);
                    }
                }

                if (victory)
                {
                    Console.Clear();
                    Console.WriteLine("guessed letters: " + printGuessedLetters);
                    Console.WriteLine("The word was: {0}", secretWord);
                    Console.WriteLine("YOU WIN!!!!!!!!!!!");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("guessed letters: " + printGuessedLetters);
                    Console.WriteLine("The word was: {0}", secretWord);
                    Console.WriteLine("YOU LOSE!!!!!!!!");
                    Console.ReadLine();
                }
            }
        }

        private static string GallowView(int livesLeft)
        {
            //print/display out the hangman
            string drawHangman = "";
            if (livesLeft < 5)
            {
                drawHangman += "--------\n";
            }

            if (livesLeft < 4)
            {
                drawHangman += "       |\n";
            }

            if (livesLeft < 3)
            {
                drawHangman += "       O\n";
            }

            if (livesLeft < 2)
            {
                drawHangman += "      /|\\ \n";
            }

            if (livesLeft == 0)
            {
                drawHangman += "      / \\ \n";
            }

            return drawHangman;
        }



    }
}
