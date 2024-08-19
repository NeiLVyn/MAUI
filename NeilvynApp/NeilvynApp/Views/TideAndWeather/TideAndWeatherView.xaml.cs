namespace NeilvynApp.Views.TideAndWeather;

public partial class TideAndWeatherView : ContentView
{
	public TideAndWeatherView()
	{
		InitializeComponent();

		sunArc.StartLabelText = "05:36";
		sunArc.EndLabelText = "18:01";
		sunArc.ArcIcon = Enums.ArcIcon.Sun;

        sunArc.RiseTime = DateTime.Parse("Aug 19, 2024 05:36");
        sunArc.SetTime = DateTime.Parse("Aug 19, 2024 18:01");
    }
}