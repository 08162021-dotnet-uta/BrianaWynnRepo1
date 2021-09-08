using System;

namespace _6_FlowControl
{
  public class Program
  {
    static void Main(string[] args)
    {
      // Console.WriteLine("Enter a username and press enter, then enter a password and press enter");
      // Register();
      // Console.WriteLine(Login());

      GiveActivityAdvice(-5);

    }

    /// <summary>
    /// This method gets a valid temperature between -40 asnd 135 inclusive 
    /// and returns the valid int. 
    /// </summary>
    /// <returns></returns>
    public static int GetValidTemperature()
    {
      int selected = 0;
      bool result = true;
      do
      {
        result = int.TryParse(Console.ReadLine(), out selected);
      } while (selected < -40 || selected > 135);

      return selected;
    }

    /// <summary>
    /// This method has one int parameter
    /// It prints outdoor activity advice and temperature opinion to the console 
    /// based on 20 degree increments starting at -20 and ending at 135 
    /// n < -20, Console.Write("hella cold");
    /// -20 <= n < 0, Console.Write("pretty cold");
    ///  0 <= n < 20, Console.Write("cold");
    /// 20 <= n < 40, Console.Write("thawed out");
    /// 40 <= n < 60, Console.Write("feels like Autumn");
    /// 60 <= n < 80, Console.Write("perfect outdoor workout temperature");
    /// 80 <= n < 90, Console.Write("niiice");
    /// 90 <= n < 100, Console.Write("hella hot");
    /// 100 <= n < 135, Console.Write("hottest");
    /// </summary>
    /// <param name="temp"></param>
    public static void GiveActivityAdvice(int temp)
    {
      switch (temp)
      {
        case < -20:
          Console.WriteLine("hella cold");
          break;
        case int n when (-20 <= n && n < 0):
          Console.WriteLine("pretty cold");
          break;
        case int n when (0 <= n && n < 20):
          Console.WriteLine("cold");
          break;
        case int n when (20 <= n && n < 40):
          Console.WriteLine("thawed out");
          break;
        case int n when (40 <= n && n < 60):
          Console.WriteLine("feels like Autumn");
          break;
        case int n when (60 <= n && n < 80):
          Console.WriteLine("perfect outdoor workout temperature");
          break;
        case int n when (80 <= n && n < 90):
          Console.WriteLine("niiice");
          break;
        case int n when (90 <= n && n < 100):
          Console.WriteLine("hella hot");
          break;
        case int n when (100 <= n && n < 135):
          Console.WriteLine("hottest");
          break;
        default:
          Console.WriteLine("Bring a jacket just in case!");
          break;
      }
    }

    /// <summary>
    /// This method gets a username and password from the user
    /// and stores that data in the global variables of the 
    /// names in the method.
    /// </summary>
    /// 
    ///

    static string userName;
    static string passWord;
    public static void Register()
    {
      Console.WriteLine("Enter your username and password");
      userName = Console.ReadLine();
      passWord = Console.ReadLine();

    }

    /// <summary>
    /// This method gets username and password from the user and
    /// compares them with the username and password names provided in Register().
    /// If the password and username match, the method returns true. 
    /// If they do not match, the user is reprompted for the username and password
    /// until the exact matches are inputted.
    /// </summary>
    /// <returns></returns>
    public static bool Login()
    {
      string userNameLogin;
      string passWordLogin;

      do
      {
        userNameLogin = Console.ReadLine();
        passWordLogin = Console.ReadLine();
        if (userNameLogin == userName && passWordLogin == passWord)
        {
          return true;
        }


      } while (userNameLogin != userName || passWordLogin != passWord);
      return true;
      // userNameLogin = Console.ReadLine();
      // passWordLogin = Console.ReadLine();

      // if (userNameLogin == userName && passWordLogin == passWord)
      // {
      //   return true;
      // }
      // else
      // {
      //   while (userNameLogin != userName || passWordLogin != passWord)
      //   {
      //     userNameLogin = Console.ReadLine();
      //     passWordLogin = Console.ReadLine();

      //   }
      //   return true;
      // }


    }

    /// <summary>
    /// This method has one int parameter.
    /// It checks if the int is <=42, Console.WriteLine($"{temp} is too cold!");
    /// between 43 and 78 inclusive, Console.WriteLine($"{temp} is an ok temperature");
    /// or > 78, Console.WriteLine($"{temp} is too hot!");
    /// For each temperature range, a different advice is given. 
    /// </summary>
    /// <param name="temp"></param>
    public static void GetTemperatureTernary(int temp)
    {
      string advice = (temp <= 42) ? $"{temp} is too cold!" : (temp >= 43 && temp <= 78) ? $"{temp} is an ok temperature" : "It's too hot!";
      Console.WriteLine(advice);
    }
  }//EoP
}//EoN
