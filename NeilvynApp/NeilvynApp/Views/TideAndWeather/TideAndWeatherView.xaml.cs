using NeilvynApp.ViewModels;

namespace NeilvynApp.Views.TideAndWeather;

public partial class TideAndWeatherView : ContentView
{
    public static EventHandler? RefreshWeatherData;

    public TideAndWeatherView()
	{
		InitializeComponent();

        RefreshWeatherData += TideAndWeatherView_RefreshWeatherData;
    }

    private void TideAndWeatherView_RefreshWeatherData(object? sender, EventArgs e)
    {
        if (BindingContext is TideAndWeatherViewModel viewModel)
        {
            viewModel.RefreshData();
        }
    }
}