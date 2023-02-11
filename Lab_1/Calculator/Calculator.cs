namespace Calculator
{
    public delegate int? Operation(int x, int y);
    public class Calculator
    {
        public Operation Add = (x, y) => x + y;
        public Operation Sub = (x, y) => x - y;
        public Operation Mul = (x, y) => x * y;
        public Operation? Div = (x, y) =>
        {
            if (y != 0) 
                return x / y;
            return null;
        };
    }
}