using GeneratePass.ViewModels;
using System.ComponentModel.Design;
using System.Text;

namespace GeneratePass.Views;

public partial class MainPage : ContentPage
{ 
	SymbolViewModel SymbolViewModel = new SymbolViewModel();
  Random random = new Random();

  public void Clicked_GenerationPassword(object sender, EventArgs e)
  {
    int count = SymbolViewModel.LengthPassword;
    StringBuilder prev = new StringBuilder();
    string password = string.Empty;
    while(count != 0)
    {
      if (numbersCheck.IsChecked)
        prev.Append(random.Next(10));
      if (lowerCheck.IsChecked)
        prev.Append(SymbolViewModel.LowerChars[random.Next(0, SymbolViewModel.LowerChars.Length)]);
      if (upperCheck.IsChecked)
        prev.Append(SymbolViewModel.UpperChars[random.Next(0, SymbolViewModel.UpperChars.Length)]);
      if (symbolCheck.IsChecked)
        prev.Append(SymbolViewModel.Symbols[random.Next(0, SymbolViewModel.Symbols.Length)]);
      password += prev[random.Next(0, prev.Length)];
      prev.Clear();
      count--;
    }
    if (lowerCheck.IsChecked)
    {
      if (!CheckCharOccurrence(SymbolViewModel.LowerChars, password))
        Clicked_GenerationPassword(sender, e);
    }
    if (upperCheck.IsChecked)
    {
      if (!CheckCharOccurrence(SymbolViewModel.UpperChars, password))
        Clicked_GenerationPassword(sender, e);
    }
    if (numbersCheck.IsChecked)
    {
      if (!CheckNumberOccurrence(password))
        Clicked_GenerationPassword(sender, e);
    }
    if (symbolCheck.IsChecked)
    {
      if (!CheckCharOccurrence(SymbolViewModel.Symbols, password))
        Clicked_GenerationPassword(sender, e);
    }
    passEntry.Text = password;
  }

  private bool CheckCharOccurrence(char[] chars, string password)
  {
    foreach(var e in chars)
    {
      if (password.Contains(e))
        return true;
    }
    return false;
  }

  private bool CheckNumberOccurrence(string password)
  {
    for (int i = 0; i < 10; i++)
    {
      if (password.Contains(i.ToString()))
        return true;
    }
    return false;
  }

  /// <summary>
  /// Взаимодействие с CheckBox.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void ClickedNumbersCheck(object sender, EventArgs e)
	{
		numbersCheck.IsChecked = !numbersCheck.IsChecked;
	}

  /// <summary>
  /// Взаимодействие с CheckBox.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void ClickedLowerCheck(object sender, EventArgs e)
	{
		lowerCheck.IsChecked = !lowerCheck.IsChecked;
	}

  /// <summary>
  /// Взаимодействие с CheckBox.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void CLickedUpperCheck(object sender, EventArgs e)
	{
		upperCheck.IsChecked = !upperCheck.IsChecked;
	}

  /// <summary>
  /// Взаимодействие с CheckBox.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void ClickedSymbolCheck(object sender, EventArgs e)
	{
		symbolCheck.IsChecked = !symbolCheck.IsChecked;
	}

  public MainPage()
  {
    InitializeComponent();
    lengthPassEntry.ValueChanged += (s, e) =>
    {
      labelSliderLengthPass.Text = Convert.ToInt32(lengthPassEntry.Value).ToString();
      SymbolViewModel.LengthPassword = Convert.ToInt32(lengthPassEntry.Value);
    };
  }
}