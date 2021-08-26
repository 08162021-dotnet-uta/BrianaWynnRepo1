using System;
using System.Collections.Generic;

namespace Calculator
{
  class Program
  {
    static void Main(string[] args)
    {
      // Robot droid = new Robot();
      // droid.SetRobot(32);
      // droid.Output();

      List<int> names = new List<int>() { 0, 1, 2, 4, 5 };
      //names.ElementAt(0);


      Console.WriteLine(names.ElementAt(1));

    }
  }

  class Robot
  {
    string type;
    double speed;

    public void SetRobot(double speed)
    {
      type = "hover";
      this.speed = speed;
    }

    public void Output()
    {
      Console.WriteLine(type + "bot has speed " + speed);
    }

  }
}
