using Model.Shared;
using System.Diagnostics;
using System.Text.Json;
using System.Windows.Input;

namespace MauiAppDesign.Pages;

public partial class WeatherForeCastPage : ContentPage
{
	HttpClient client;
    private HttpClient _client;
    JsonSerializerOptions _serializerOptions;

	public List<WeatherForecast> Items { get; private set; }

	public WeatherForeCastPage()
	{
		InitializeComponent();
		BindingContext = this;
		_client = new HttpClient();
		_serializerOptions = new JsonSerializerOptions
		{
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			WriteIndented = true,
		};
	}

	bool isRefreshing;
   

    public bool IsRefreshing
	{
		get { return isRefreshing; }
		set 
		{
			isRefreshing = value;
			OnPropertyChanged();
		}

	}


    public ICommand RefreshCommand => new Command(async () => IstWeather.ItemsSource = await RefreshDataAsync());
   

    public async Task<List<WeatherForecast>> RefreshDataAsync()
	{
		Items = new List<WeatherForecast>();

		Uri uri = new Uri ("https://lz9v86zg-7138.asse.devtunnels.ms/WeatherForecast");
		try
		{
			HttpResponseMessage response = await _client.GetAsync(uri);
			if (response.IsSuccessStatusCode) 
			{
				string content = await response.Content.ReadAsStringAsync();
				Items = JsonSerializer.Deserialize<List<WeatherForecast>>(content, _serializerOptions);

			}
			IsRefreshing = false;
		}
		catch (Exception ex)
		{
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
		}

		return Items;
	}
}