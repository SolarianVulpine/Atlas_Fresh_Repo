using GuessingGame;

var gameManager = new GameManager();

do
{
        Console.Clear();
        gameManager.InitGame();

        GuessResult result;
        do
        {
                int guess = ConsoleIO.PromptForGuess();
                result = gameManager.ProcessGuess(guess);
                ConsoleIO.DisplayResult(result);
        } while (result != GuessResult.Correct);

        Console.WriteLine($"You took {gameManager.GuessCount} guesses.");

} while (ConsoleIO.PromptPlayAgain());
