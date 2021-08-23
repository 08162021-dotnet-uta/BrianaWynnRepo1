using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // input stuff
            var input1 = int.Parse(Console.ReadLine()); //type inference
            var input2 = int.Parse(Console.ReadLine());
            // compute stuff
            var compute = input1 + input2; 
            // output stuff
            Console.WriteLine(compute);
        }
    }
}
