namespace GeneratePass.Services
{
  class ValidatePassword
  {
    /// <summary>
    /// Проверка на вхождение символа в строку.
    /// </summary>
    /// <param name="characters">Массив символов.</param>
    /// <param name="password">Строка.</param>
    /// <returns>Вложенность.</returns>
    public bool CheckCharOccurrence(char[] characters, string password)
    {
      foreach (char character in characters)
      {
        if (password.Contains(character))
          return true;
      }
      return false;
    }
  }
}
