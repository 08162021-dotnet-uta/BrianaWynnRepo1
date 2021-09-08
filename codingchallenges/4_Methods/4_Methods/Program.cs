using System;

namespace _4_MethodsChallenge
{
  public class Program
  {
    public static void Main(string[] args)
    {
      //1
      // string name = GetName();
      // GreetFriend(name);

      //2
      double result1 = GetNumber();
      double result2 = GetNumber();
      //int action1 = GetAction();
      //double result3 = DoAction(result1, result2, action1);

      //System.Console.WriteLine($"The result of your mathematical operation is {result3}.");
    }

    public static string GetName()
    {
      Console.WriteLine("What's your name?");
      return Console.ReadLine();

    }

    public static string GreetFriend(string name)
    {
      return ("Hello, " + name + "You are my friend.");
    }

    public static double GetNumber()
    {
      bool result;
      double validDouble;
      do
      {
        Console.WriteLine("Please enter a number ");

        result = double.TryParse(Console.ReadLine(), out validDouble);

      } while (!result);

      return validDouble;


    }

    public static int GetAction()
    {
      bool result;
      int validInt;
      do
      {
        Console.WriteLine("Please enter a number  ");

        result = int.TryParse(Console.ReadLine(), out validInt);

      } while (!result);

      return validInt;

    }

    public static double DoAction(double x, double y, int action)
    {
      throw new NotImplementedException("DoAction() is not implemented yet");
    }
  }
}
