using System.Text.Json;

namespace  Lab2.DataFilter;

class Program
{
    static void Main(string[] args)
    {
        IEnumerable<Student> filterdStudents = new List<Student>();

        // Get information from .json file
        var path = "/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_2/dataFilter/Students.json";
        var jsonInformation = File.ReadAllText(path);
        var students = JsonSerializer.Deserialize<Student[]>(jsonInformation);

        // Choosing operation and number to operate with
        // Output the result
        Console.WriteLine("Оберіть операцію: >/</=");
        var operation = Console.ReadLine()!;
        
        Console.WriteLine("Введіть число для порівняння");
        var number = Console.ReadLine()!;
        
        // Main process
        HandleOperation(operation, Int32.Parse(number));
        
        foreach (Student student in filterdStudents) 
        {
            Console.WriteLine($"{student.Name} має оцінку {student.AverageGrade}");
        }
        
        // Operation to handle filtering
        // Filtering the list with lambda expression
        void HandleOperation(string operation, int numberToCompare)
        {
            if(operation == ">")
                filterdStudents = students.Where(student => student.AverageGrade > numberToCompare);
            else if(operation == "<")
                filterdStudents = students.Where(student => student.AverageGrade < numberToCompare);
            else if(operation == "=")
                filterdStudents = students.Where(student => student.AverageGrade == numberToCompare);
        }
    }
}

