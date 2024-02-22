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
  /// ������ ����.
  /// </summary>
  /// <param name="sender">�������.</param>
  /// <param name="e">������ �������.</param>
  public void sevenButton_Clicked(object sender, EventArgs e)
	{
    EnteringNumber("7");
	}

  /// <summary>
  /// ������ ������.
  /// </summary>
  /// <param name="sender">�������.</param>
  /// <param name="e">������ �������.</param>
  public void eightButton_Clicked(object sender, EventArgs e)
	{
    EnteringNumber("8");
  }

  /// <summary>
  /// ������ ������.
  /// </summary>
  /// <param name="sender">�������.</param>
  /// <param name="e">������ �������.</param>
  public void nineButton_Clicked(object sender, EventArgs e)
	{
    EnteringNumber("9");
  }

  /// <summary>
  /// ������ �������.
  /// </summary>
  /// <param name="sender">�������.</param>
  /// <param name="e">������ �������.</param>
  public void divisionButton_Clicked(object sender, EventArgs e)
  {
    EnteringSign("/");
  }

  /// <summary>
  /// ������ ������.
  /// </summary>
  /// <param name="sender">�������.</param>
  /// <param name="e">������ �������.</param>
  public void fourButton_Clicked(object sender, EventArgs e)
  {
    EnteringNumber("4");
  }

  /// <summary>
  /// ������ ����.
  /// </summary>
  /// <param name="sender">�������.</param>
  /// <param name="e">������ �������.</param>
  public void fiveButton_Clicked(object sender, EventArgs e)
  {
    EnteringNumber("5");
  }

  /// <summary>
  /// ������ �����.
  /// </summary>
  /// <param name="sender">�������.</param>
  /// <param name="e">������ �������.</param>
  public void sixButton_Clicked(object sender, EventArgs e)
  {
    EnteringNumber("6");
  }

  /// <summary>
  /// ������ ���������.
  /// </summary>
  /// <param name="sender">�������.</param>
  /// <param name="e">������ �������.</param>
  public void multiButton_Clicked(object sender, EventArgs e)
  {
    EnteringSign("*");
  }

  /// <summary>
  /// ������ ����.
  /// </summary>
  /// <param name="sender">�������.</param>
  /// <param name="e">������ �������.</param>
  public void oneButton_Clicked(object sender, EventArgs e)
  {
    EnteringNumber("1");
  }

  /// <summary>
  /// ������ ���.
  /// </summary>
  /// <param name="sender">�������.</param>
  /// <param name="e">������ �������.</param>
  public void twoButton_Clicked(object sender, EventArgs e)
  {
    EnteringNumber("2");
  }

  /// <summary>
  /// ������ ���.
  /// </summary>
  /// <param name="sender">�������.</param>
  /// <param name="e">������ �������.</param>
  public void threeButton_Clicked(object sender, EventArgs e)
  {
    EnteringNumber("3");
  }

  /// <summary>
  /// ������ �����.
  /// </summary>
  /// <param name="sender">�������.</param>
  /// <param name="e">������ �������.</param>
  public void minusButton_Clicked(object sender, EventArgs e)
  {
    EnteringSign("-");
  }

  /// <summary>
  /// ������ ����.
  /// </summary>
  /// <param name="sender">�������.</param>
  /// <param name="e">������ �������.</param>
  public void zeroButton_Clicked(object sender, EventArgs e)
  {
    EnteringNumber("0");
  }

  /// <summary>
  /// ������ ��������� �����.
  /// </summary>
  /// <param name="sender">�������.</param>
  /// <param name="e">������ �������.</param>
  public void pointButton_Clicked(object sender, EventArgs e)
  {
    EnteringNumber(",");
  }

  /// <summary>
  /// ������ ����.
  /// </summary>
  /// <param name="sender">�������.</param>
  /// <param name="e">������ �������.</param>
  public void plusButton_Clicked(object sender, EventArgs e)
  {
    EnteringSign("+");
  }

  /// <summary>
  /// ������ ��������.
  /// </summary>
  /// <param name="sender">�������.</param>
  /// <param name="e">������ �������.</param>
  public void clearButton_Clicked(Object sender, EventArgs e)
  {
    isNewOperation = true;
    ValueViewModel.Value = "0";
    queue.Clear();
    fieldEntry.Text = ValueViewModel.Value;
  }

  /// <summary>
  /// ������ �����.
  /// </summary>
  /// <param name="sender">�������.</param>
  /// <param name="e">������ �������.</param>
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
  /// ��������� ����� �����.
  /// </summary>
  /// <param name="value">��������.</param>
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
  /// ��������� �����.
  /// </summary>
  /// <param name="value">��������.</param>
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