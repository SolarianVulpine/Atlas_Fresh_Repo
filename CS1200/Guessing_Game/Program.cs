using GuessingGame;
using INumberGenerator;


int numberGeneratorChoice;

Console.Write("Choose the number generator:\n1. Test\n2. Random Number Generator\n Console Input\n");
Console.Write("Enter your choice (1-3):");
numberGeneratorChoice = int.Parse(Console.Readline);

switch (numberGeneratorChoice)
{
        case 1:
                var gameManager = new GameManager(TestNumberGenerator);
                gameManager.InitGame;
                break;
        case 2:
                var gameManager = new GameManager(RandomNumberGenerator);
                break;
        case 3:
                var gameManager = new GameManager(ConsoleNumberGenerator);
                break;
}


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
