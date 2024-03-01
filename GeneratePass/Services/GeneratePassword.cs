using System.Text;

namespace GeneratePass.Services
{
  class GeneratePassword
  {
    /// <summary>
    /// Список массива символов.
    /// </summary>
    private List<char[]> Characters {  get; set; }
    
    /// <summary>
    /// Длина пароля.
    /// </summary>
    private int LengthPassword { get; set; }

    ValidatePassword validatePassword = new();

    /// <summary>
    /// Получить пароль.
    /// </summary>
    /// <returns>Пароль.</returns>
    public string GetPassword()
    {
      string password = Generate();
      foreach (char[] character in Characters)
      {
        if (!validatePassword.CheckCharOccurrence(character, password))
          GetPassword();
      }
      return password;
    }

    /// <summary>
    /// Генерация пароля.
    /// </summary>
    /// <returns>Сгенерированный пароль.</returns>
    public string Generate()
    {
      Random random = new();
      int count = LengthPassword;
      StringBuilder prev = new();
      StringBuilder password = new();
      while (count != 0)
      {
        foreach (char[] character in Characters)
        {
          prev.Append(character[random.Next(0, character.Length)]);
        }
        password.Append(prev[random.Next(0, prev.Length)]);
        prev.Clear();
        count--;
      }
      return password.ToString();
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="characters">Список массивов символов.</param>
    /// <param name="lengthPassword">Длина пароля.</param>
    public GeneratePassword(List<char[]> characters, int lengthPassword)
    {
      Characters = characters;
      LengthPassword = lengthPassword;
    }
  }
}
