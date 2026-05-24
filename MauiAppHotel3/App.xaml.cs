using Microsoft.Extensions.DependencyInjection;

namespace MauiAppHotel3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.NewPage1());

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Width = 400;
            window.Height = 600;
            return window;
        }
    }
}