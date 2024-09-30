using Model.Shared;


namespace MauiAppDesign.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await BottomBorder.ScaleTo(1.10, 1000);
        await BottomBorder.ScaleTo(1, 100);
        await Shell.Current.GoToAsync("WeatherForecast");
        await DisplayAlert("WeatherForecast", "You tapped WeatherForecast", "continue");
    }

    private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        await imgheart.ScaleTo(1.10, 1000);
        await imgheart.ScaleTo(1, 100);
        await DisplayAlert("Favorite", "You tapped Favorite", "continue");

    }

    private async void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
    {
        await imgpfp.ScaleTo(1.10, 1000);
        await imgpfp.ScaleTo(1, 100);
        await DisplayAlert("Profile", "You tapped Profile", "continue");
    }

    private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}