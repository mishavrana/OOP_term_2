using System.Text.Json;

namespace Lab2.DataGroup;

class Program
{
    static void Main(string[] args)
    {
        IEnumerable<IGrouping<bool, Product>> filteredProducts = new List<IGrouping<bool, Product>>();
        
        // Get information from .json file
        var path = "/Users/mishavrana/Documents/KNUTE/Term_4/OOP/Practical/Lab_2/dataGroup/Products.json";
        var products = Handler.Decode(path);
        
        // Get the grouping object
        // Output the information
        Console.WriteLine("Enter grouping criteria: p - price/ g - group ");
        var groupCriteria = Console.ReadLine()!;

        string groupingObject = "";
        
        if (groupCriteria == "p")
        {
            Console.WriteLine("Enter the hightest price you can afford: ");
            groupingObject = Console.ReadLine()!; 
        } else if(groupCriteria == "g")
        {
            Console.WriteLine("Choose the group: f - fruits/ v - vegetables/ m - meat / d - diary/ b - bakery");
            groupingObject = Console.ReadLine()!;
        }
        
        // Handle grouping
        filteredProducts = Handler.Group(groupCriteria, groupingObject, products);

        foreach (var group in filteredProducts)
        {
            if (group.Key)
            {
                foreach (var product in group)
                {
                    Console.WriteLine(product.Name);
                } 
            }
        }
    }
}