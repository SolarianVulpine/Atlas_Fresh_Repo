namespace GuessingGame;

public class GameManager
{
        private Random random = new Random();
        private int numberToGuess;
        public int GuessCount { get; private set; }

        public void InitGame()
        {
                // numberToGuess = random.Next(1, 21);
                GuessCount = 0;
        }

        public GuessResult ProcessGuess(int guess)
        {
                GuessCount++;
                if (guess < numberToGuess)
                        return GuessResult.Higher;
                else if (guess > numberToGuess)
                        return GuessResult.Lower;
                else
                        return GuessResult.Correct;
        }
}
