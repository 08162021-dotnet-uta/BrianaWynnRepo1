using System;
using System.Collections.Generic;

namespace _8_LoopsChallenge
{
  public class Program
  {
    public static void Main(string[] args)
    {
      /* Your code here */

    }

    /// <summary>
    /// Return the number of elements in the List<int> that are odd.
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static int UseFor(List<int> x)
    {
      int oddNums = 0;
      for (int i = 0; i < x.Count; i++)
      {
        if (x[i] % 2 != 0)
        {
          oddNums++;
        }
      }
      return oddNums;
    }

    /// <summary>
    /// This method counts the even entries from the provided List<object> 
    /// and returns the total number found.
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static int UseForEach(List<object> x)
    {

      int evenNums = 0;

      foreach (object y in x)
      {

        if (y is int || y is UInt64 || y is Int64)
        {
          if ((int)y % 2 == 0)
          {
            evenNums++;
          }
        }

      }
      return evenNums;
    }
    /// <summary>
    /// This method counts the multiples of 4 from the provided List<int>. 
    /// Exit the loop when the integer 1234 is found.
    /// Return the total number of multiples of 4.
    /// </summary>
    /// <param name="x"></param>
    public static int UseWhile(List<int> x)
    {
      // int Fours = 0;
      // var y = 0;
      // while (y != 1234)
      // {
      //   foreach (var y in x)
      //   {
      //     if (y % 4 == 0)
      //     {
      //       Fours++;
      //     }
      //   }
      // }
      // return Fours;
      return 0;
    }

    /// <summary>
    /// This method will evaluate the Int Array provided and return how many of its 
    /// values are multiples of 3 and 4.
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static int UseForThreeFour(int[] x)
    {
      throw new NotImplementedException("UseForThreeFour() is not implemented yet.");
    }

    /// <summary>
    /// This method takes an array of List<string>'s. 
    /// It concatenates all the strings, with a space between each, in the Lists and returns the resulting string.
    /// </summary>
    /// <param name="stringListArray"></param>
    /// <returns></returns>
    public static string LoopdyLoop(List<string>[] stringListArray)
    {
      string final = null;
      for (int x = 0; x < stringListArray.Length; x++)
      {
        foreach (string s in stringListArray[x])
        {
          final += s + " ";
        }
      }
      return final;
    }
  }
}