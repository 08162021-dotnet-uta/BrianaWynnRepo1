using System;

namespace _9_ClassesChallenge
{
  public class Program
  {
    public static void Main(string[] args)
    {

      Human briana = new Human();
      Human b2 = new Human("Briana", "Wynn");
      Console.WriteLine(b2.AboutMe());
      Console.WriteLine(briana.AboutMe());

      // Human2 b3 = new Human2("Briana", "Wynn", "Brown", 24);
      // b3.

      Human2 b4 = new Human2("Briana", "Wynn", "Brown");
      Console.WriteLine(b4.AboutMe2());

      Human2 b5 = new Human2("Brittany", "Snow", 52);
      Console.WriteLine(b5.AboutMe2());

      Human2 b6 = new Human2("John", "White", "Blue", 15);
      Console.WriteLine(b6.AboutMe2());

      Human2 b7 = new Human2("Pat", "Smyth");
      Console.WriteLine(b7.AboutMe2());

      // b7.Weight = 152;
      // b6.Weight = 600;
      // Console.WriteLine("human 7 weight {0} and briana 8 weight {1}", b7.Weight, b6.Weight);


    }
  }
}
