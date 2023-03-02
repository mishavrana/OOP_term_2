using System.Security.Principal;
using System.Text.Json;

namespace task_2;

class Program
{
    private static Handler _handler = new Handler();
    
    private static double? _price;
    private static string? _group;
    
    // Get products from json file
    private static Predicate<Product> productFitsPrice = product => product.Price < _price;
    private static Predicate<Product> productFitsGroup = product => product.Group == _group;
    
    // Show data 
    private static Action<Product> outputProduct =
        product => Console.WriteLine($"{product.Name} - {product.Group} - {product.Price}");
    
    // Closure that logs pathes that was used
    private static Action SavePaths()
    {
        var paths = filePaths;

        void Logger()
        {
            string json = JsonSerializer.Serialize(filePaths);
            
            File.WriteAllText($"/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_3/task_2/Logs/{DateTime.Now}_paths.json", json);
        }
        return Logger;
    }
    
    // Closure that logs filtering parameters
    private static Action SaveFilteringParams(string criteria, string value)
    {
        void Logger()
        {
            using (var writer = new StreamWriter($"/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_3/task_2/Logs/{DateTime.Now}_filtering_params.txt", true))
            {
                writer.WriteLine($"Criteria: {criteria}");
                writer.WriteLine($"Value: {value}");
            }
        }

        return Logger;
    }
    

        private static string[] filePaths =
    {
        "/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_3/task_2/Jsons/1.json",
        "/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_3/task_2/Jsons/2.json",
        "/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_3/task_2/Jsons/3.json",
        "/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_3/task_2/Jsons/4.json",
        "/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_3/task_2/Jsons/5.json",
        "/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_3/task_2/Jsons/6.json",
        "/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_3/task_2/Jsons/7.json",
        "/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_3/task_2/Jsons/8.json",
        "/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_3/task_2/Jsons/9.json",
        "/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_3/task_2/Jsons/10.json",
    };
    
    static void Main(string[] args)
    {
        List<Product> products = _handler.LoadDataFromJson(filePaths);
        List<Product> filteredProducts = new List<Product>();
        
        Console.WriteLine("Choose the criteria of filtering: 1 - group 2 - price");
        
        var criteria = Console.ReadLine()!;
        
        switch (criteria)
        {
            case "1": 
                _group = ChooseGroup();
                filteredProducts = _handler.FilterProducts(products, productFitsGroup);
                break;;
            case "2": 
                _price = SetPrice();
                filteredProducts = _handler.FilterProducts(products, productFitsPrice);
                break;
        }
        
        foreach (var product in  filteredProducts)
        {
            outputProduct(product);
        }

        // Logging the paths 
        var savePaths = SavePaths();
        savePaths();
        
        // Logging the filtering params
        var saveFileteringParams = SaveFilteringParams(criteria, _price == null? _group : _price.ToString());
        saveFileteringParams();

        // Choose the group of products from user's input
        string ChooseGroup()
        {
            string groupOfProducts = "";
            
            Console.WriteLine("Choose the group of products:");
            Console.WriteLine("1 - Fruit, 2 - Vegetables 3 - Fish, 4 - Confectionery, 5 - Dairy, 6 - Meat");
            
            string group = Console.ReadLine()!;
            
            switch (group)
            {
                case "1": groupOfProducts = "Fruit"; break;
                case "2": groupOfProducts = "Vegetables"; break;
                case "3": groupOfProducts = "Fish"; break;
                case "4": groupOfProducts = "Confectionery"; break;
                case "5": groupOfProducts = "Dairy"; break;
                case "6": groupOfProducts = "Meat"; break;
            }
            
            return groupOfProducts;
        }

        // Choose the upper bount of price form user's input
        double SetPrice()
        {
            Console.WriteLine("Enter the upper bound of price: ");
            var price = Double.Parse(Console.ReadLine()!);
            return price;
        }
    }
}