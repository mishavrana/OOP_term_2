using System;

namespace RandomNumbersAverage_2
{
    public delegate double Average(int x, int y, int z);
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(average(2, 4, 7));
        }

        private static Average average = delegate(int x, int y, int z)
        {
            return Math.Round(Convert.ToDouble(x + y + z) / 3, 2);
        };
    }
}