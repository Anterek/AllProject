using System.Text;

namespace GeneratePass.Services
{
  class GeneratePassword
  {
    /// <summary>
    /// Генерация случайной последовательности символов.
    /// </summary>
    /// <param name="characters">Список массивов символов.</param>
    /// <param name="lengthPassword">Длина пароля.</param>
    /// <returns>Пароль.</returns>
    public string Generate(List<char[]> characters, int lengthPassword)
    {
      ValidatePassword validatePassword = new();
      Random random = new();
      int count = lengthPassword;
      StringBuilder prev = new();
      StringBuilder password = new();
      while (count != 0)
      {
        foreach (char[] character in characters)
        {
          prev.Append(character[random.Next(0, character.Length)]);
        }
        password.Append(prev[random.Next(0, prev.Length)]);
        prev.Clear();
        count--;
      }
      foreach (char[] character in characters)
      {
        if (!validatePassword.CheckCharOccurrence(character, password.ToString()))
          Generate(characters, lengthPassword);
      }
      return password.ToString();
    }
  }
}
