namespace GuessingGame;
// using INumberGenerator;

public class GameManager
{
        private INumberGenerator _numberGenerator;
        private int numberToGuess;
        public int GuessCount { get; private set; }

        public GameManager(INumberGenerator numberGenerator)
        {
                _numberGenerator = numberGenerator;
        }


        public void InitGame()
        {
                Console.WriteLine("made it");
                // numberToGuess = 
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
