using GeneratePass.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace GeneratePass.ViewModels
{
  internal class SymbolViewModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler? PropertyChanged;

    SymbolModel symbolModel = new SymbolModel();

    /// <summary>
    /// Свойство.
    /// </summary>
    public char[] NumberChars
    {
      get => symbolModel.NumberChars!;
    }

    /// <summary>
    /// Свойство.
    /// </summary>
    public int LengthPassword
    {
      get => symbolModel.LengthPassword;
      set
      {
        symbolModel.LengthPassword = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// Свойство.
    /// </summary>
    public char[] LowerChars
    {
      get => symbolModel.lowerChars!;
    }

    /// <summary>
    /// Свойство.
    /// </summary>
    public char[] UpperChars
    {
      get => symbolModel.UpperChars!;
    }

    /// <summary>
    /// Свойство.
    /// </summary>
    public char[] Symbols
    {
      get => symbolModel.Symbols!;
    }

    /// <summary>
    /// Уведомление об изменении свойств.
    /// </summary>
    /// <param name="prop">Имя свойства.</param>
    public void OnPropertyChanged([CallerMemberName] string prop="")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
  }
}
