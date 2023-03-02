namespace task_2;

public class ItemEqualityComparer : IEqualityComparer<Product>
{
    public bool Equals(Product x, Product y)
    {
        // Two items are equal if their keys are equal.
        return x.Name == y.Name && x.Group == y.Group && x.Price == y.Price;
    }
    
    public int GetHashCode(Product obj)
    {
        return obj.Name.GetHashCode();
    }
}