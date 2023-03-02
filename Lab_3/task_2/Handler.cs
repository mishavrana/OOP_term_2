using System.Text.Json;
using System.Text.Json.Nodes;

namespace task_2;

public class Handler
{
    // Load data from json
    public List<Product> LoadDataFromJson(string[] paths)
    {
        List<Product> products = new List<Product>(); 
        foreach (var path in paths)
        {
            string jsonData = File.ReadAllText(path);
            products.AddRange(JsonSerializer.Deserialize<List<Product>>(jsonData));
        }
        
        return products.Distinct(new ItemEqualityComparer()).ToList();
    }

    // Filter data from json
    public List<Product> FilterProducts(List<Product> products, Predicate<Product> filter)
    {
        List<Product> filteredProducts = new List<Product>();

        foreach (var product in products)
        {
            if (filter(product))
            {
                filteredProducts.Add(product);
            }
        }
        return filteredProducts;
    }
}