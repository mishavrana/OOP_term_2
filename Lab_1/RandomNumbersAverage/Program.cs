using System;
using System.Linq;
using System.Security.Cryptography;

namespace RandomNumbersAverage
{
    public delegate int RandomGenerator();
    public delegate int Average(RandomGenerator[] randomNumbers);
    
    internal class Program
    {
        private static RandomGenerator _randomGenerator = Randomize;
        
        private static RandomGenerator[] _randomGenerators = new RandomGenerator[10];
        
        public static void Main(string[] args)
        {
            // Fill up an array of delegates
            for (int i = 0; i < 10; i++)
            {
                _randomGenerators[i] = _randomGenerator;
            }

            Console.WriteLine(average(_randomGenerators));
        }

        
        // Function that randomize numbers
        private static int Randomize()
        {
            Random randomizer = new Random();
            return(randomizer.Next(1,100));
        }
        
        // Creating an anonymous method 
        private static Average average = delegate(RandomGenerator[] randomNumbers)
        {
            var sum = 0;
            for (var i = 0; i < randomNumbers.Length; i++)
            {
                sum += randomNumbers[i]();
            }
            return sum / randomNumbers.Length;
        };
    }
}