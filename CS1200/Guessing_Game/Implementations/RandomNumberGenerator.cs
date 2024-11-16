// using INumberGenerator;

//  Generates a random number within a specified range using the Random class. 
//  It should have a constructor that accepts the minimum and maximum values for the range.
public class RandomNumberGenerator : INumberGenerator
{
        public int min;
        public int max;
        public int numberToGuess;

        // constructor taking minimum and maximum
        public RandomNumberGenerator(int min, int max)
        {
                this.min = min;
                this.max = max;
        }
        private Random random = new Random(); // seeds a new random value

        public int GenerateNumber()
        {
                int numberToGuess = random.Next(min, max + 1);
                return (numberToGuess);
        }
}