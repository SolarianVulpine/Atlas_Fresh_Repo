namespace Hangman.BLL.Interfaces;

public class ConsoleWordGet : IWordSource
{
        public string GetWord()
        {
                Console.Clear();
                Console.Write("Enter the word to guess: ");

                string input = Console.ReadLine();
                if (string.IsNullorWhiteSpace(input))
                {
                        throw new InvalidOperationException("No word entered");
                }

                return input;
        }
}