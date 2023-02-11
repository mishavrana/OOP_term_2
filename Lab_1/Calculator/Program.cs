using System;

namespace Calculator
{
    internal class Program
    {
        private static Calculator _calculator = new Calculator();
        private static bool _isEnd = false;
        public static void Main(string[] args)
        {
            while (!_isEnd)
            {
                Console.WriteLine("Choose the operation: ");
                Console.WriteLine("a - for add, s - for subtract, m - for multiply, d - for divide");

                var operation = Console.ReadLine()!;
                
                Console.WriteLine("Enter the fist number for the operation");
                var x = Console.ReadLine()!;
                Console.WriteLine("Enter the second number for the operation");
                var y = Console.ReadLine()!;

                int? _result = null;
                var _operationSign = "";

                // Choose the operation
                switch (operation)
                {
                    case "a": 
                        _result = _calculator.Add(int.Parse(x), int.Parse(y));
                        _operationSign = "+";
                        break;
                    case "s": 
                        _result = _calculator.Sub(int.Parse(x), int.Parse(y));
                        _operationSign = "-";
                        break;
                    case "m": 
                        _result = _calculator.Mul(int.Parse(x), int.Parse(y)); 
                        _operationSign = "*";
                        break;
                    case "d":
                        _result = _calculator.Div(int.Parse(x), int.Parse(y));
                        _operationSign = "d";
                        break;
                    default: 
                        Console.WriteLine("Wrong operation!"); 
                        break;
                }

                if (_result?.ToString() != null)
                    Console.WriteLine($" {x} {_operationSign} {y} = {_result}");
                else 
                    Console.WriteLine("ERROR");

                    // End part
                Console.WriteLine("To end press 'n', else press any key: ");
                var endCommand = Console.ReadLine()!;
                if (endCommand == "n")
                    _isEnd = true;
            }

        }
        
    }
}