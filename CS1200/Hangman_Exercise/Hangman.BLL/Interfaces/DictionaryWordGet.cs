namespace Hangman.BLL.Interfaces;

public class DictionaryWordGet : IWordSource
{
        public string[] _words;
        Random _random = new Random();
        public DictionaryWordGet(string filePath)
        {
                _words = File.ReadAllLines(filePath);
        }
        public string GetWord()
        {
                if (_words.Length == 0)
                        throw new InvalidOperationException("Dictionary file is empty");
                return _words[_random.Next(_words.Length)];
        }
}