using NeilvynApp.Core.Location;
using NeilvynApp.Core.Services;
using NeilvynApp.Core;
using Newtonsoft.Json;
using NeilvynApp.Models.Dto;
using Location = NeilvynApp.Core.Location.Location;
using NeilvynApp.Views.TideAndWeather;
using NeilvynApp.Models;
using NeilvynApp.Core.Helpers;

namespace NeilvynApp.ViewModels
{
    public class TideAndWeatherViewModel : PropertyChangeNotifier, IContentViewReloader
    {
        private readonly ILocationService? _locationService;
        private readonly IApiService? _apiService;

        private CurrentAreaDto? _CurrentAreaData = default(CurrentAreaDto);
        public CurrentAreaDto CurrentAreaData { get => _CurrentAreaData; set { _CurrentAreaData = value; RaisePropertyChanged(nameof(CurrentAreaData)); } }

        private OneCallDto? _OneCallData = default(OneCallDto);
        public OneCallDto OneCallData { get => _OneCallData; set { _OneCallData = value; RaisePropertyChanged(nameof(OneCallData)); } }

        private OneCallCurrentWeatherDto? _CurrentWeatherData = default(OneCallCurrentWeatherDto);
        public OneCallCurrentWeatherDto CurrentWeatherData { get => _CurrentWeatherData; set { _CurrentWeatherData = value; RaisePropertyChanged(nameof(CurrentWeatherData)); } }

        private bool IsFirstLoad = true;
        private bool _IsLoading = true;
        public bool IsLoading { get => _IsLoading; set { _IsLoading = value; RaisePropertyChanged(nameof(IsLoading)); } }


        public TideAndWeatherViewModel()
        {
            _apiService = ServiceHelper.GetService<IApiService>() ?? throw new InvalidOperationException(nameof(_apiService));
            _locationService = ServiceHelper.GetService<ILocationService>() ?? throw new InvalidOperationException(nameof(_locationService));
        }

        public async void RefreshData()
        {
            if(IsFirstLoad)
            {
                IsFirstLoad = false;
                IsLoading = true;
            }

            await GetCurrentWeather();
            await GetCurrentLocationArea();
            IsLoading = false;
        }

        private async Task GetCurrentWeather()
        {
            try
            {
                if (_locationService != null && _apiService != null)
                {
                    var position = await _locationService.GetCurrentLocationAsync();

                    if (position != null)
                    {
                        var uri = $"https://api.openweathermap.org/data/2.5/onecall?units=metric&appid={Constants.OpenWeatherMap_Key}&lat={position.Latitude}&lon={position.Longitude}";

                        string resp = await _apiService.GetAsync(uri);

                        if (!string.IsNullOrEmpty(resp))
                        {
                            OneCallData = JsonConvert.DeserializeObject<OneCallDto>(resp);

                            if (OneCallData != null)
                            {
                                CurrentWeatherData = OneCallData.Current.Weather.FirstOrDefault();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task GetCurrentLocationArea()
        {
            try
            {
                if (_locationService != null && _apiService != null)
                {
                    var position = await _locationService.GetCurrentLocationAsync();

                    if (position != null)
                    {
                        var uri = $"https://api.openweathermap.org/data/2.5/weather?appid={Constants.OpenWeatherMap_Key}&lat={position.Latitude}&lon={position.Longitude}";

                        var resp = await _apiService.GetAsync(uri);

                        if (resp != null)
                        {
                            CurrentAreaData = JsonConvert.DeserializeObject<CurrentAreaDto>(resp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
