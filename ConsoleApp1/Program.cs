using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Wrong arguments!!!");
                Console.ReadKey();
                return;
            }
            if (int.TryParse(args[0], out int num1) && int.TryParse(args[1], out int num2))
            {
                switch (args[2])
                {
                    case "+":
                        Console.WriteLine($"Result: {num1 + num2}");
                        break;
                    case "-":
                        Console.WriteLine($"Result: {num1 - num2}");
                        break;
                    case "*":
                        Console.WriteLine($"Result: {num1 * num2}");
                        break;
                    case "/":
                        Console.WriteLine($"Result: {num1 / num2}");
                        break;
                    default:
                        Console.WriteLine("Invalid operation!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid numbers!");
            }

            Console.ReadKey();
        }
    }
}
