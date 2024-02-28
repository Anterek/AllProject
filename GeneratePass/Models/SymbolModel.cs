using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratePass.Models
{
  internal class SymbolModel
  {
    public int LengthPassword { get; set; } = 5;

    public char[]? lowerChars { get; set; } = GetChars(97, 122);
    public char[]? UpperChars { get; set; } = GetChars(65, 90);
    public char[]? Symbols { get; set; } = { '!', '@', '#', '$', '%', '&', '*', '(', ')', '[', ']', '{', '}' };

    public static char[] GetChars(int start, int end)
    {
      char[] masLower = new char[end - start];
      int count = start;
      for (int i = 0; i < end - start; i++)
      {
        masLower[i] = (char)count;
        count++;
      }
      return masLower;
    }
  }
}
