
namespace Calculate
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();

      MainPage = new AppShell();
    }

    /// <summary>
    /// Определение размеров окна.
    /// </summary>
    /// <param name="activationState">Состояние активации.</param>
    /// <returns></returns>
    protected override Window CreateWindow(IActivationState? activationState)
    {
      var window = base.CreateWindow(activationState);
      var width = 270;
      var height = 420;
      window.MaximumWidth = width;
      window.MaximumHeight = height;
      window.MinimumHeight = height;
      window.MinimumWidth = width;
      return window;
    }
  }
}
