using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            localhost.MathServices proxy = new localhost.MathServices();
            
            Console.WriteLine(proxy.Add(144, 36));
            Console.WriteLine("Addition web service consumed");
            Console.WriteLine(proxy.Subtract(5421, 564));
            Console.WriteLine("Subtraction web service consumed");
            Console.WriteLine(proxy.Multiply(2131, 84));
            Console.WriteLine("Multiplication web service consumed");
            Console.WriteLine(proxy.Divide(2004, 152));
            Console.WriteLine("Division web service consumed");
            Console.ReadLine();
        }
    }
}
