using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_C_Sharp_Features {
    internal class Program {
        // Anonymous methods: a method without name we are defining it with delegate keyword, typically used for 
        // commonly used with delegates
        // events
        // lambda expressions
        delegate void displayMessage(string message); //Creating a delegate
        static void Main(string[] args) {
            // using delegate to create anonymous method
            displayMessage msg = delegate (string text) 
            { Console.WriteLine(text); };
            // calling an anonymous method
            msg("This is a text message coming from an Anonymous method call ...!!!");

            // above task can be done in a line using lambda expression in C# Console.WriteLine("If we are using lambda epxression "); displayMyMessage MyMsg = (text) => Console.WriteLine(text);
            Console.WriteLine("If we are using lambda epxression then we can do this in a line ..!!");
            displayMessage MyMsg = (text) => Console.WriteLine(text);
            MyMsg("here is a text displayed using Lambda Expression in C# ");

            Func<int, int, int> add = (a, b) => a + b; 
            Console.WriteLine("Sum of two number is" + add(4, 9));

            Console.WriteLine("Action<T> delegate in action ");
            Action<string> print = (text) => Console.WriteLine(text);
            print("Here is a text printed using Action<T> delegate ");

            List <int> List = new List<int> { 1, 5, 6, 8, 9 };
            var evenNumber = List.Where(x => x % 2 == 0);

            Console.WriteLine("If we are using lambda epxression then we can do this in a line ..!!");
            displayMessage MyMsg2 = (text) => Console.WriteLine(text);
            MyMsg2("here is a text displayed using Lambda Expression in C# ");
        }
    }
} 
