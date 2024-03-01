using Calculate.ViewModels;

namespace Calculate.Views;

public partial class MainForm : ContentPage
{
  ValueViewModel ValueViewModel = new ValueViewModel();
  Queue<string> queue = new Queue<string>();
  bool isNewOperation = true;

	public MainForm()
	{
		InitializeComponent();

	}

  /// <summary>
  /// Кнопка семь.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void sevenButton_Clicked(object sender, EventArgs e)
	{
    EnteringNumber("7");
	}

  /// <summary>
  /// Кнопка восемь.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void eightButton_Clicked(object sender, EventArgs e)
	{
    EnteringNumber("8");
  }

  /// <summary>
  /// Кнопка девять.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void nineButton_Clicked(object sender, EventArgs e)
	{
    EnteringNumber("9");
  }

  /// <summary>
  /// Кнопка деления.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void divisionButton_Clicked(object sender, EventArgs e)
  {
    EnteringSign("/");
  }

  /// <summary>
  /// Кнопка четыре.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void fourButton_Clicked(object sender, EventArgs e)
  {
    EnteringNumber("4");
  }

  /// <summary>
  /// Кнопка пять.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void fiveButton_Clicked(object sender, EventArgs e)
  {
    EnteringNumber("5");
  }

  /// <summary>
  /// Кнопка шесть.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void sixButton_Clicked(object sender, EventArgs e)
  {
    EnteringNumber("6");
  }

  /// <summary>
  /// Кнопка умножения.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void multiButton_Clicked(object sender, EventArgs e)
  {
    EnteringSign("*");
  }

  /// <summary>
  /// Кнопка один.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void oneButton_Clicked(object sender, EventArgs e)
  {
    EnteringNumber("1");
  }

  /// <summary>
  /// Кнопка два.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void twoButton_Clicked(object sender, EventArgs e)
  {
    EnteringNumber("2");
  }

  /// <summary>
  /// Кнопка три.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void threeButton_Clicked(object sender, EventArgs e)
  {
    EnteringNumber("3");
  }

  /// <summary>
  /// Кнопка минус.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void minusButton_Clicked(object sender, EventArgs e)
  {
    EnteringSign("-");
  }

  /// <summary>
  /// Кнопка ноль.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void zeroButton_Clicked(object sender, EventArgs e)
  {
    EnteringNumber("0");
  }

  /// <summary>
  /// Кнопка плавающей точки.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void pointButton_Clicked(object sender, EventArgs e)
  {
    EnteringNumber(",");
  }

  /// <summary>
  /// Кнопка плюс.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void plusButton_Clicked(object sender, EventArgs e)
  {
    EnteringSign("+");
  }

  /// <summary>
  /// Кнопка очистить.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void clearButton_Clicked(Object sender, EventArgs e)
  {
    isNewOperation = true;
    ValueViewModel.Value = "0";
    queue.Clear();
    fieldEntry.Text = ValueViewModel.Value;
  }

  /// <summary>
  /// Кнопка равно.
  /// </summary>
  /// <param name="sender">Событие.</param>
  /// <param name="e">Данные события.</param>
  public void equalluButton_Clicked(object sender, EventArgs e)
  {
    queue.Enqueue(ValueViewModel.Value);
    if (queue.Count == 0 || queue.Count == 1)
      fieldEntry.Text = ValueViewModel.Value;
    else
    {
      ValueViewModel.Sub = Convert.ToDouble(queue.Dequeue());
      while (queue.Count > 0)
      {
        switch (queue.Peek())
        {
          case "/":
            if (ValueViewModel.Sub != 0)
            {
              queue.Dequeue();
              if (queue.Count > 0)
                ValueViewModel.Sub /= Convert.ToDouble(queue.Dequeue());
              else
                break;
            }
            else
            {
              queue.Clear();
            }
            break;
          case "*":
            queue.Dequeue();
            if (queue.Count > 0)
              ValueViewModel.Sub *= Convert.ToDouble(queue.Dequeue());
            else
              break;
            break;
          case "-":
            queue.Dequeue();
            if (queue.Count > 0)
              ValueViewModel.Sub -= Convert.ToDouble(queue.Dequeue());
            else
              break;
            break;
          case "+":
            queue.Dequeue();
            if (queue.Count > 0)
              ValueViewModel.Sub += Convert.ToDouble(queue.Dequeue());
            else
              break;
            break;
        }
      }
      ValueViewModel.Value = ValueViewModel.Sub.ToString();
      fieldEntry.Text = ValueViewModel.Value;
      isNewOperation = true;
    }
  }

  /// <summary>
  /// Обработка ввода числа.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void EnteringNumber(string value)
  {
    if(isNewOperation == true)
    {
      ValueViewModel.Value = string.Empty;
      fieldEntry.Text = "0";
    }
    ValueViewModel.Value += value;
    fieldEntry.Text = ValueViewModel.Value;
    isNewOperation = false;
  }

  /// <summary>
  /// Обработка знака.
  /// </summary>
  /// <param name="value">Значение.</param>
  public void EnteringSign(string value)
  {
    char[] sign = { '/', '*', '-', '+' };
    if (queue.Count > 0)
    {
      if (sign.Any(queue.Peek().Contains))
      {
        queue.Dequeue();
        queue.Enqueue(value);
        return;
      }
    }
    queue.Enqueue(ValueViewModel.Value.ToString());
    queue.Enqueue(value);
    ValueViewModel.Value = string.Empty;
    fieldEntry.Text = value;
    isNewOperation = false;
  }
}