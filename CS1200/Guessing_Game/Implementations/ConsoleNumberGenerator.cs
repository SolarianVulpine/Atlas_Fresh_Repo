// using INumberGenerator;

// Prompts the user to enter a number within a specified range.
// It should have a constructor that accepts the minimum and maximum values for the range.
public class ConsoleNumberGenerator : INumberGenerator
{
        public int min;
        public int max;
        public int numberToGuess;

        public ConsoleNumberGenerator(int min, int max) {
                this.min = min;
                this.max = max;
        }
        public int GenerateNumber()
        {
                Console.Write($"Enter the number to guess ({min}-{max}): ");
                numberToGuess = Console.ReadLine();

                return(numberToGuess);
        }

}