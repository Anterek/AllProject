using GeneratePass.Services;
using GeneratePass.ViewModels;

namespace GeneratePass.Views;

public partial class MainPage : ContentPage
{
	SymbolViewModel SymbolViewModel = new();

  /// <summary>
  /// Кнопка генерации пароля.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void Clicked_GenerationPassword(object sender, EventArgs e)
  {
    List<char[]> characters = new();
    if (numbersCheck.IsChecked)
      characters.Add(SymbolViewModel.NumberChars);
    if(lowerCheck.IsChecked)
      characters.Add(SymbolViewModel.LowerChars);
    if (upperCheck.IsChecked)
      characters.Add(SymbolViewModel.UpperChars);
    if (symbolCheck.IsChecked)
      characters.Add(SymbolViewModel.Symbols);
    GeneratePassword generatePassword = new(characters, SymbolViewModel.LengthPassword);
    passEntry.Text = generatePassword.GetPassword();
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

  /// <summary>
  /// Конструктор.
  /// </summary>
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