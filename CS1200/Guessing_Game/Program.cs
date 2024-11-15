using GuessingGame;
using INumberGenerator;


int numberGeneratorChoice;
var gameManager = new GameManager(numberGeneratorChoice);

Console.Clear;
Console.WriteLine("Choose the number generator:\n1. Test\n2. Random Number Generator\n3. Console Input");
Console.Write("Enter your choice (1-3): ");
numberGeneratorChoice = Console.ReadLine;

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
