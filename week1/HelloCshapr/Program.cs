using System;

namespace HelloCshapr
{
    class Program
    {
      //Build a simple calculator using 5 methods: Add, Multiply, subtract, divide, print, 
       
        public double add(double a, double b){
         return: a + b; 

        }

        public double subtract(double a, double b){
          return: a -b; 
        }

        public double multiply(double a, double b){
          return a*b;
        }
        public double divide(double a, double b){
          return a/b; 
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Winnie!");
            Console.ReadLine();
        }
    }
}
