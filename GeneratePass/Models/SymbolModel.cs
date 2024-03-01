namespace GeneratePass.Models
{
  internal class SymbolModel
  {
    /// <summary>
    /// Длина пароля.
    /// </summary>
    public int LengthPassword { get; set; } = 5;

    /// <summary>
    /// Массив чисел.
    /// </summary>
    public char[]? NumberChars { get; set; } = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

    /// <summary>
    /// Массив символов нижнего регистра.
    /// </summary>
    public char[]? lowerChars { get; set; } = GetChars(97, 122);

    /// <summary>
    /// Массив символов верхнего регистра.
    /// </summary>
    public char[]? UpperChars { get; set; } = GetChars(65, 90);

    /// <summary>
    /// Массив символов.
    /// </summary>
    public char[]? Symbols { get; set; } = { '!', '@', '#', '$', '%', '&', '*', '(', ')', '[', ']', '{', '}' };

    /// <summary>
    /// Заполнение массива символами.
    /// </summary>
    /// <param name="start">Начало позиции ASKII.</param>
    /// <param name="end">Конец позиции ASKII.</param>
    /// <returns></returns>
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
