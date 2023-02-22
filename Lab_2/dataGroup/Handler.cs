using System.Text.Json;

namespace Lab2.DataGroup;

public static class Handler
{
    // Get information from .json file
    public static IEnumerable<Product> Decode(string path)
    {
        var jsonInformation = File.ReadAllText(path);
        var products = JsonSerializer.Deserialize<Product[]>(jsonInformation);
        return products;
    }
    
    // Operation to handle grouping
    // Grouping with lambda expression
    public static IEnumerable<IGrouping<bool, Product>> Group(string operation, string value, IEnumerable<Product> products)
    {
        IEnumerable<IGrouping<bool, Product>> filteredProducts = new List<IGrouping<bool, Product>>();
        if (operation == "p")
            filteredProducts = products.GroupBy(product => product.Price < Decimal.Parse(value));
        else if (operation == "g")
        {
            switch (value)
            {
                case "f": 
                    filteredProducts = products.GroupBy(product => product.Group == "Fruits");
                    break;
                case "v": 
                    filteredProducts = products.GroupBy(product => product.Group == "Vegetables");
                    break;
                case "m": 
                    filteredProducts = products.GroupBy(product => product.Group == "Meat");
                    break;
                case "d": 
                    filteredProducts = products.GroupBy(product => product.Group == "Diary");
                    break;
                case "b": 
                    filteredProducts = products.GroupBy(product => product.Group == "Bakery");
                    break;
            }
        }

        return filteredProducts;
    }
}