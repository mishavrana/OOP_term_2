namespace Task_1;

class Program
{
    private static string dateFormat = "yyyy-MM-dd";
    private static string filePath = "/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_3/task_1/time_and_price.csv";
    
    private static Func<string, DateTime> GetDate = s => DateTime.ParseExact(s, dateFormat, null);
    private static Func<string, double> GetPrice = s => Double.Parse(s)!;
    
    private static Action<DateTime, double> OutputTotalByMonth = (date, price) =>
    {
        Console.WriteLine($"{date.ToString()}: {price}");
    };

    // Log the date format
    private static Action SaveDataFormat(string dateFormat)
    {
        void Logger()
        {
            using (var writer = new StreamWriter($"/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_3/task_1/Logs/{DateTime.Now}_dateFormat.txt", true))
            {
                writer.WriteLine(dateFormat);
            }
        }

        return Logger;
    }
    
    // Log tha path
    private static Action SavePath(string path)
    {
        void Logger()
        {
            using (var writer = new StreamWriter($"/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_3/task_1/Logs/{DateTime.Now}_path.txt", true))
            {
                writer.WriteLine(path);
            }
        }

        return Logger;
    }

    static void Main(string[] args)
    {
        // Read the CSV file and group them by data
        var result = File.ReadAllLines(filePath)
            .Skip(1)
            .Select(line => line.Split(","))
            .Select(fields => new { Date = GetDate(fields[0]), Price = GetPrice(fields[1]) });

        // Write the result to the new CSV file(10 rows for the file)
        int fileIndex = 0;
        
        foreach (var pair in result)
        {
            if (fileIndex % 10 == 0)
            {
                string outputFilePath = $"/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_3/task_1/NewFiles/output-{fileIndex / 10}.csv";
                using (var writer = new StreamWriter(outputFilePath))
                {
                    writer.WriteLine("Date,Total");
                }
                
                // Save path for new files
                var savePath = SavePath(filePath);
                savePath();
            }

            using (var writer = new StreamWriter($"/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_3/task_1/NewFiles/output-{fileIndex / 10}.csv", true))
            {
                writer.WriteLine($"Date: {pair.Date.ToString(dateFormat)} Price: { pair.Price.ToString()}");
            }
            fileIndex++;
        }
        
        // Otput total by day
        double total = 0;
        foreach(var group in result.GroupBy(date => date.Date))
        {
            foreach (var transaction in group)
            {
                total += transaction.Price;
            }
            OutputTotalByMonth(group.First().Date, total);
            total = 0;
        }
        
        // Save the date format
        var saveDataFormat = SaveDataFormat(dateFormat);
        saveDataFormat();

    }
}