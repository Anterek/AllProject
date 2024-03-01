namespace GeneratePass
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();

      MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
      var window = base.CreateWindow(activationState);
      var width = 360;
      var height = 600;
      window.MaximumWidth = width;
      window.MaximumHeight = height;
      window.MinimumHeight = height;
      window.MinimumWidth = width;
      return window;
    }
  }
}
