using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Transactions;

namespace Hangman.Bll;



public class PlayGame
{

        private readonly IWordSource wordSource;
        private readonly List<char> guessedLetters = new List<char>();

        public IWordSource Object { get; }

        public object GetGuessedLetters()
        {
                throw new NotImplementedException();
        }

        public bool GuessedLetters(object obj)
        {
                throw new NotImplementedException();
        }

        public void PlayRound(object @object)
        {
                throw new NotImplementedException();
        }


        public void StartGame()
        {
                Console.WriteLine("Welcome to Hangman!");
                Console.WriteLine("Enter your name:  ");
                string name = Console.ReadLine();


                while (true)
                {
                        Console.WriteLine("How would you like to choose your words?");
                        Console.WriteLine("1. Enter the word in the console window.");
                        Console.WriteLine("2. Pick a random word from the dictionary for me.");
                        Console.Write("Enter choice: ");
                        int UserInput = int.Parse(Console.ReadLine());
                        IWordSource wordSource;

                        if (UserInput == 1)
                        {
                                wordSource = new ConsoleWordGet();
                                string WordToGuess = wordSource.GetWord();
                                PlayRound(WordToGuess);



                        }
                        else if (UserInput == 2)
                        {
                                wordSource = new DictionaryWordGet("dictionary.txt");
                                string WordToGuess = wordSource.GetWord();
                                Console.WriteLine($"A random word has been selected from the dictionary, it is {WordToGuess.Length} letters long.");
                                Console.Write("Press any key to continue...");
                                Console.ReadKey();

                                PlayRound(WordToGuess);
                        }
                        else
                        {
                                Console.WriteLine("Invalid choice. Please choose 1 or 2."); // Handle invalid input
                        }





                        Console.Write("Play another game (y/n): ");
                        string playAgain = Console.ReadLine().ToLower();
                        if (playAgain != "y")
                        {
                                break; // Exit the loop if user doesn't want to play again
                        }

                }



                void PlayRound(string WordToGuess)
                {

                        Console.Write(WordToGuess);


                        int TriesRemaining = 5;
                        int Wins = 0;
                        int Losses = 0;
                        char[] guessedLetters = new char[WordToGuess.Length];
                        Array.Fill(guessedLetters, '_');

                        bool IsWordGuessed(char[] guessedLetters)
                        {
                                foreach (char letter in guessedLetters)
                                {
                                        if (letter == '_')
                                        {
                                                return false;
                                        }
                                }
                                return true;
                        }


                        string GetGuess()
                        {
                                Console.Write("Enter Guess: ");
                                string guess = Console.ReadLine();
                                return guess;

                        }

                        void DisplayWord(char[] guessedLetters)
                        {
                                Console.Clear();
                                Console.WriteLine($"Strikes Remaining: {TriesRemaining}");
                                foreach (char letter in guessedLetters)
                                {
                                        Console.Write(letter + " ");
                                }
                                Console.WriteLine();
                        }

                        int CountLetters(string WordToGuess, char letter)
                        {

                                int count = 0;

                                foreach (char p in WordToGuess)
                                {
                                        if (p == letter)
                                        {
                                                count++;
                                        }
                                }
                                return count;
                        }


                        while (TriesRemaining > 0 && !IsWordGuessed(guessedLetters))
                        {

                                DisplayWord(guessedLetters);

                                string guess = GetGuess();
                                int correctLetters = CountLetters(WordToGuess, guess[0]);
                                bool correctGuess = false;
                                if (guess.Length == 1) // Single character guess
                                {
                                        for (int i = 0; i < WordToGuess.Length; i++)
                                        {
                                                if (WordToGuess[i] == guess[0])
                                                {
                                                        correctGuess = true;
                                                        guessedLetters[i] = guess[0];

                                                        Console.WriteLine($"We found {correctLetters} of those!");
                                                        Console.Write("Press any key to continue...");
                                                        Console.ReadKey();
                                                }
                                        }
                                }

                                if (!correctGuess)
                                {

                                        Console.WriteLine("Sorry,that was not found!");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();

                                        TriesRemaining--;
                                }


                                if (guess.Equals(WordToGuess, StringComparison.OrdinalIgnoreCase))
                                {
                                        for (int i = 0; i < WordToGuess.Length; i++)
                                        {
                                                guessedLetters[i] = WordToGuess[i];
                                        }
                                        break; // Exit the loop if the whole word is guessed correctly
                                }
                        }





                        if (IsWordGuessed(guessedLetters))
                        {
                                Console.WriteLine($"{name} guessed the word. They win!");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                Wins++;
                                PlayerRecord();

                        }
                        if (TriesRemaining == 0)
                        {
                                Console.WriteLine($"{name} ran out of strikes. They lose!");
                                Console.WriteLine("The word was: {WordToGuess}");
                                Losses++;
                                PlayerRecord();

                        }
                        void PlayerRecord()
                        {
                                Console.WriteLine($"{name}'s record: {Wins}W-{Losses}L");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                        }

                }


        }
}


