using System.Text.Json;

namespace Lab2.dataSort;

class Program
{
    static void Main(string[] args)
    {
        IEnumerable<Employee> filterdEmployees = new List<Employee>();

        // Get information from .json file
        var path = "/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_2/dataSort/Stuff.json";
        var jsonInformation = File.ReadAllText(path);
        var employees = JsonSerializer.Deserialize<Employee[]>(jsonInformation);

        // Choosing sort object and ouput the result
        Console.WriteLine("Оберіть об'єкт сортування: s - зарплатня, e - досвіт роботи");
        var sortObject = Console.ReadLine()!;
        
        HandleOperation(sortObject);

        foreach (Employee employee in filterdEmployees)
        {
            if(sortObject == "s")
                Console.WriteLine($"{employee.Name}  має заробітню плату: {employee.Salary}");
            if(sortObject == "e")
                Console.WriteLine($"{employee.Name}  має досвід: {employee.Experience}");
        }
        
        // Operation to handle sorting
        // Sorting the list with lambda expression
        void HandleOperation(string sortObject)
        {
            if(sortObject == "s")
                filterdEmployees = employees.OrderBy(employee => employee.Salary );
            else if (sortObject == "e")
                filterdEmployees = employees.OrderBy(employee => employee.Experience);
        }
    }
}
