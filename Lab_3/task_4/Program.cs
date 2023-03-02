namespace task_4;

class Program
{
    private static FileHandler _fileHandler = new FileHandler();
    static void Main(string[] args)
    {
        var files = new List<string>()
        {
            @"/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_3/task_4/Files/1.txt",
            @"/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_3/task_4/Files/2.txt"
        };
        
        var wordFrequencyDict = new Dictionary<string, int>();
        
        foreach (var fileName in files)
        {
            var fileText = File.ReadAllText(fileName);
            var words = _fileHandler.tokenizer(fileText);
            var wordCounts = _fileHandler.wordCounter(words);

            foreach (var wordCount in wordCounts)
            {
                if (!wordFrequencyDict.ContainsKey(wordCount.Key))
                {
                    wordFrequencyDict.Add(wordCount.Key, wordCount.Value);
                }
                else
                {
                    wordFrequencyDict[wordCount.Key] += wordCount.Value;
                }
            }
        }

        _fileHandler.reportGenerator(wordFrequencyDict);
    }
}