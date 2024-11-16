using GuessingGame;
using INumberGenerator;


int numberGeneratorChoice;
var gameManager = new GameManager(numberGeneratorChoice);

00

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
