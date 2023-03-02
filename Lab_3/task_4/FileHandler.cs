namespace task_4;

public class FileHandler
{

    public Func<string, IEnumerable<string>> tokenizer = TokenizeFile;
    public Func<IEnumerable<string>, IDictionary<string, int>> wordCounter = CountWords;
    public Action<IDictionary<string, int>> reportGenerator = GenerateReport;
    
    // Tokenize file    
    private static IEnumerable<string> TokenizeFile(string fileText)
    {
        return fileText.ToLower().Split(new char[] { ' ', ',', '.', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
    }
    
    // Count words in the file
    private static IDictionary<string, int> CountWords(IEnumerable<string> words)
    {
        var wordCountDict = new Dictionary<string, int>();

        foreach (var word in words)
        {
            if (!wordCountDict.ContainsKey(word))
            {
                wordCountDict.Add(word, 1);
            }
            else
            {
                wordCountDict[word] += 1;
            }
        }
        return wordCountDict;
    }
    
    // Generate report 
    private static void GenerateReport(IDictionary<string, int> wordFrequencyDict)
    {
        foreach (var wordFrequency in wordFrequencyDict.OrderByDescending(wf => wf.Value))
        {
            Console.WriteLine($"{wordFrequency.Key}: {wordFrequency.Value}");
        }
    }
    
}