using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
  internal class Human2 : Human
  {
    private string eyeColor;
    private int age;
    private int _weight;

    public int Weight
    {
      get
      {

        return _weight;
      }

      set
      {
        if (_weight < 0 || _weight > 400)
        {
          _weight = 0;
        }
      }
    }

    // private int _weight;
    // public int weight
    // {
    //   get
    //   {
    //     _weight = weight;
    //     return _weight;
    //   }
    //   set
    //   {
    //     if (value < 0 || 400 > value)
    //     {
    //       _weight = 0;
    //     }
    //     else
    //     {
    //       this.weight = value;
    //     }

    //   }
    // }

    public Human2() { }
    public Human2(string fName, string lName) : base(fName, lName) { }
    public Human2(string fName, string lName, string eyeColor, int age) : base(fName, lName)
    {

      this.eyeColor = eyeColor;
      this.age = age;
    }

    public Human2(string fname, string lName, int age) : base(fname, lName)
    {
      this.age = age;
    }

    public Human2(string fname, string lName, string eyeColor) : base(fname, lName)
    {

      this.eyeColor = eyeColor;
    }

    public string AboutMe2()
    {

      if (this.eyeColor != null && this.age != 0)
      {
        return AboutMe() + $" My age is {this.age}. My eye color is {this.eyeColor}.";
      }
      else if (this.eyeColor != null)
      {
        return AboutMe() + $" My eye color is {this.eyeColor}.";
      }
      else if (this.age != 0)
      {
        return AboutMe() + $" My age is {this.age}.";
      }
      return AboutMe();

    }
  }//EoC
}//EoN