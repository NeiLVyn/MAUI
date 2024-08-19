using NeilvynApp.Views.TideAndWeather;

namespace NeilvynApp.Views.Dashboard;

public partial class Dashboard : ContentPage
{
    public Dashboard()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        containerView.Padding = new Thickness(0, 0, 0, 10);
        TabSwitcher(2);
    }

    private void OnTapped_TabMenu_Bloodline(object sender, TappedEventArgs e)
    {
        TabSwitcher(0);
    }

    private void OnTapped_TabMenu_Weather(object sender, TappedEventArgs e)
    {
        TabSwitcher(1);
        TideAndWeatherView.RefreshWeatherData.Invoke(this, EventArgs.Empty);
    }

    private void OnTapped_TabMenu_Map(object sender, TappedEventArgs e)
    {
        TabSwitcher(2);
    }

    private void OnTapped_TabMenu_Chat(object sender, TappedEventArgs e)
    {
        TabSwitcher(3);
    }

    private void OnTapped_TabMenu_About(object sender, TappedEventArgs e)
    {
        TabSwitcher(4);
    }

    private void TabSwitcher(int index = 2)
    {
        if (indicator != null)
        {
            Grid.SetColumn(indicator, index);
        }
        imgBloodline.Source = index == 0 ? "bloodline_dark.png" : "bloodline_light.png";
        imgBloodline.Margin = index == 0 ? new Thickness(0, -20, 0, 20) : new Thickness(0, 0, 0, 0);
        lblBloodline.Text = index == 0 ? "Bloodline" : "";
        viewBloodline.IsVisible = index == 0;

        imgWeather.Source = index == 1 ? "weather_dark.png" : "weather_light.png";
        imgWeather.Margin = index == 1 ? new Thickness(0, -20, 0, 20) : new Thickness(0, 0, 0, 0);
        lblWeather.Text = index == 1 ? "Weather" : "";
        viewWeather.IsVisible = index == 1;

        imgMap.Source = index == 2 ? "map_dark.png" : "map_light.png";
        imgMap.Margin = index == 2 ? new Thickness(0, -20, 0, 20) : new Thickness(0, 0, 0, 0);
        lblMap.Text = index == 2 ? "Map" : "";
        viewMap.IsVisible = index == 2;

        imgChat.Source = index == 3 ? "chat_dark.png" : "chat_light.png";
        imgChat.Margin = index == 3 ? new Thickness(0, -20, 0, 20) : new Thickness(0, 0, 0, 0);
        lblChat.Text = index == 3 ? "Chat" : "";
        viewChat.IsVisible = index == 3;

        imgAbout.Source = index == 4 ? "about_dark.png" : "about_light.png";
        imgAbout.Margin = index == 4 ? new Thickness(0, -20, 0, 20) : new Thickness(0, 0, 0, 0);
        lblAbout.Text = index == 4 ? "About" : "";
        viewAbout.IsVisible = index == 4;
    }
}