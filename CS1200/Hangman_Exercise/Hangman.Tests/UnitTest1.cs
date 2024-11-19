
using Hangman.BLL;

namespace Hangman.Tests
{

    public class UnitTest1
    {
        //private readonly object m;

        [Fact]
        public void IsWordGuessed_ShouldReturnTrue_WhenAllLettersGuessed()
        {


            bool IsWordGuessed(char[] guessedLetters)
            {
                foreach (char letter in guessedLetters)
                {
                    if (letter == '_')
                    {
                        return false;
                    }
                }
                return true;
            }

            char[] guessedLetters = new char[] { 'h', 'e', 'l', 'l', 'o' };
            PlayGame game = new();
            bool isWordGuessed = IsWordGuessed(guessedLetters);
            Assert.True(isWordGuessed);
        }


    }
}