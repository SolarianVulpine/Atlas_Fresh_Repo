namespace GuessingGame;

public static class ConsoleIO
{
        public static int PromptForGuess()
        {
                int guess;
                while (true)
                {
                        Console.Write("Enter your guess (1-20): ");
                        if (int.TryParse(Console.ReadLine(), out guess) && guess >= 1 && guess <= 20)
                        {
                                return guess;
                        }
                        Console.WriteLine("Invalid guess. Please enter a number between 1 and 20.");
                }
        }

        public static void DisplayResult(GuessResult result)
        {
                switch (result)
                {
                        case GuessResult.Higher:
                                Console.WriteLine("Too low! Guess higher.");
                                break;
                        case GuessResult.Lower:
                                Console.WriteLine("Too high! Guess lower.");
                                break;
                        case GuessResult.Correct:
                                Console.WriteLine("Congratulations! You guessed the correct number.");
                                break;
                }
        }

        // if they say anything other than 'y' we will interpret that as no.
        public static bool PromptPlayAgain()
        {
                Console.Write("Do you want to play again? (y/n): ");
                return Console.ReadLine().ToLower() == "y";
        }
}