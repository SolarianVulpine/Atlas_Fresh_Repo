using Hangman.BLL;

namespace Hangman.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            PlayGame game = new();
            game.startGame();

        }
    }
}