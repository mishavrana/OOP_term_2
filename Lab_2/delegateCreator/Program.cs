namespace Lab2.DelegateCreator;

public delegate int StringCount(string row);
class Program
{
    static void Main(string[] args)
    {
        // Creating a delegate with lambda expression
        StringCount operation = row => row.Length;
        
        // Output information 
        Console.WriteLine(operation("success"));
    }
}
