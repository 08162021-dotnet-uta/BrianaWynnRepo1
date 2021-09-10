using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
  internal class Human
  {

    // private string lName { get; set; }
    // private string fName { get; set; }

    private string Lname = "Smyth";
    private string Fname = "Pat";

    public Human()
    {

    }

    public Human(string fName, string lName)
    {
      Fname = fName;
      Lname = lName;

    }

    public string AboutMe()
    {
      return $"My name is {Fname} {Lname}";

    }





  }//end of class
}//end of namespace