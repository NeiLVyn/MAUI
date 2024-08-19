using NeilvynApp.ViewModels;

namespace NeilvynApp.Views.TideAndWeather;

public partial class TideAndWeatherView : ContentView
{
    public static EventHandler? RefreshWeatherData;

    public TideAndWeatherView()
	{
		InitializeComponent();

        //      sunArc.StartLabelText = "05:36";
        //sunArc.EndLabelText = "18:01";
        //sunArc.ArcIcon = Enums.ArcIcon.Moon;
        //sunArc.CenterImage = "dotnet_bot";
        //sunArc.TitleLabel = "Waning Gibbous";

        //      sunArc.RiseTime = DateTime.Parse("Aug 19, 2024 05:36");
        //      sunArc.SetTime = DateTime.Parse("Aug 19, 2024 18:01");

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