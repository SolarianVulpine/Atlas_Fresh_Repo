namespace Hangman.BLL;

public class DictionaryWordGet(string filePath) : IWordSource
{
        public string[] _words = File.ReadAllLines(filePath);
        Random _random = new Random();

    public string GetWord()
        {
                if (_words.Length == 0)
                {
                        throw new InvalidOperationException("Dictionary file is empty");
                }
                return _words[_random.Next(_words.Length)];
        }
}
