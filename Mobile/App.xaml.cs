namespace Mobile
{
    public partial class App : Application
    {
        const int Width = 1200;
        const int Height = 750;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = Width;
            window.Height = Height;

            return window;
        }
    }
}
