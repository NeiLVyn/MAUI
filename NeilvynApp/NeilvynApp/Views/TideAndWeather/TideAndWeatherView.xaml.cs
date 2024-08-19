using NeilvynApp.ViewModels;

namespace NeilvynApp.Views.TideAndWeather;

public partial class TideAndWeatherView : ContentView
{
    public static EventHandler? RefreshWeatherData;
    public static EventHandler<string>? WeatherIcon;

    public TideAndWeatherView()
	{
		InitializeComponent();

        RefreshWeatherData += TideAndWeatherView_RefreshWeatherData;
        WeatherIcon += TideAndWeatherView_WeatherIcon;
    }

    private void TideAndWeatherView_WeatherIcon(object? sender, string img)
    {
        imgWeatherIcon.Source = img;
    }

    private void TideAndWeatherView_RefreshWeatherData(object? sender, EventArgs e)
    {
        if (BindingContext is TideAndWeatherViewModel viewModel)
        {
            viewModel.RefreshData();
        }
    }
}