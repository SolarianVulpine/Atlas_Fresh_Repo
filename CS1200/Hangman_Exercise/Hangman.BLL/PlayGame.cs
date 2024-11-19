namespace Hangman.BLL
{
        public class PlayGame
        {
                private readonly IWordSource wordSource;
                private readonly List<char> guessedLetters = new List<char>();
                public IWordSource Object { get; }
                public object GetGuess()
                {
                        throw new NotImplementedException();
                }
                public bool GuessedLetters(object obj)
                {
                        throw new NotImplementedException();
                }
                public void Rounds(object _object)
                {
                        throw new NotImplementedException();
                }

                public void startGame()
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

                                int input = int.Parse(Console.ReadLine());
                                IWordSource _wordSource;

                                switch (input)
                                {
                                        case 1:
                                                _wordSource = new ConsoleWordGet();
                                                string _wordtoGuess = _wordSource.GetWord();
                                                Rounds(_wordtoGuess);
                                                break;
                                        case 2:
                                                _wordSource = new DictionaryWordGet("dictionary.txt");
                                                _wordtoGuess = _wordSource.GetWord();
                                                Console.WriteLine($"A random word has been selected from the dictionary, it is {_wordtoGuess.Length} letters long.");
                                                Console.Write("Press any key to continue...");
                                                Console.ReadKey();

                                                Rounds(_wordtoGuess);
                                                break;
                                        default:
                                                Console.WriteLine("Invalid choice. Please choose 1 or 2.");
                                                break;
                                }


                                // if (input == 1)
                                // {
                                //         _wordSource = new ConsoleWordGet();
                                //         string _wordtoGuess = _wordSource.GetWord;
                                //         Rounds(_wordtoGuess);
                                // }
                                // else if (input == 2)
                                // {
                                //         _wordSource = new DictionaryWordGet("dictionary.txt");
                                //         string _wordtoGuess = _wordSource.GetWord();
                                //         Console.WriteLine($"A random word has been selected from the dictionary, it is {_wordtoGuess.Length} letters long.");
                                //         Console.Write("Press any key to continue...");
                                //         Console.ReadKey();

                                //         Rounds(_wordtoGuess);
                                // }
                                // else
                                // {
                                //         Console.WriteLine("Invalid choice. Please choose 1 or 2.");
                                // }

                                Console.Write("Play another game (y/n): ");
                                string replayInput = Console.ReadLine().ToLower();
                                if (replayInput != "y")
                                {
                                        break;
                                }
                                else
                                {
                                        continue;
                                }
                        }

                        void Rounds(string _wordtoGuess)
                        {
                                Console.Write(_wordtoGuess);

                                int remainingAttempts = 5;
                                int winCount = 0;
                                int lossCount = 0;
                                char[] GuessedLetters = new char[_wordtoGuess.Length];
                                for (int i = 0; i < _wordtoGuess.Length; i++)
                                {
                                        GuessedLetters[i] = '_';
                                }

                                bool winCheck(char[] GuessedLetters)
                                {
                                        for(int i = 0; i < GuessedLetters.Length; i++)
                                        {
                                                if(GuessedLetters[i] == '_')
                                                {
                                                      return false;  
                                                }
                                        }
                                        return true;
                                }

                                string GetGuess()
                                {
                                        Console.Write("Enter Guess: ");
                                        string guessInput = Console.ReadLine();
                                        return(guessInput);
                                }

                                void displayProgress(char[] GuessLetters)
                                {
                                        Console.Clear();
                                        Console.WriteLine($"Strikes Remaining: {remainingAttempts}");
                                        foreach (char letter in GuessedLetters)
                                        {
                                                Console.Write(letter + " ");
                                        }
                                        Console.WriteLine();
                                }

                                int letterCount(string _wordtoGuess, char letter)
                                {
                                        int count = 0;

                                        foreach (char t in _wordtoGuess)
                                        {
                                                if (t == letter)
                                                {
                                                        count++;
                                                }
                                        }
                                        return(count);
                                }

                                while (remainingAttempts > 0 && !winCheck(GuessedLetters))
                                {
                                        displayProgress(GuessedLetters);

                                        string guess = GetGuess();
                                        int revealedLetters = letterCount(_wordtoGuess, guess[0]);
                                        bool correctTf2 = false;
                                        if (guess.Length == 1)
                                        {
                                                for (int i = 0; i < _wordtoGuess.Length; i++)
                                                {
                                                        if (_wordtoGuess[i] == guess[0])
                                                        {
                                                                correctTf2 = true;
                                                                GuessedLetters[i] = guess[0];


                                                                Console.WriteLine($"We found {revealedLetters} of those!");
                                                                Console.Write("Press any key to continue...");
                                                                Console.ReadKey();
                                                        }
                                                }
                                        }

                                        if (!correctTf2)
                                        {
                                                Console.WriteLine("Sorry,that was not found!");
                                                Console.WriteLine("Press any key to continue...");
                                                Console.ReadKey();

                                                remainingAttempts--;
                                        }

                                        if (guess.Equals(_wordtoGuess, StringComparison.OrdinalIgnoreCase)) ;
                                        {
                                                for (int i = 0; i < _wordtoGuess.Length; i++)
                                                {
                                                        GuessedLetters[i] = _wordtoGuess[i];
                                                }
                                                break;
                                        }
                                }

                                if (winCheck(GuessedLetters))
                                {
                                        Console.WriteLine($"{name} guessed the word. They win!");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        winCount++;
                                        PlayerRecord();

                                }
                                if (remainingAttempts == 0)
                                {
                                        Console.WriteLine($"{name} ran out of strikes. They lose!");
                                        Console.WriteLine("The word was: {WordToGuess}");
                                        lossCount++;
                                        PlayerRecord();

                                }
                                void PlayerRecord()
                                {
                                        Console.WriteLine($"{name}'s record: {winCount}W-{lossCount}L");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                }

                        }
                }
        }

}
