using MauiAppDesign.Pages;

namespace MauiAppDesign
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            Routing.RegisterRoute("explorerpage", typeof(ExplorerPage));
            Routing.RegisterRoute("WeatherForecast", typeof(WeatherForeCastPage));

        }
    }
}
