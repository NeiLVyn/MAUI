using NeilvynApp.Core.Location;
using NeilvynApp.Core.Services;
using NeilvynApp.Core;
using Newtonsoft.Json;
using NeilvynApp.Models.Dto;

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


        public TideAndWeatherViewModel()
        {
            _apiService = ServiceHelper.GetService<IApiService>() ?? throw new InvalidOperationException(nameof(_apiService));
            _locationService = ServiceHelper.GetService<ILocationService>() ?? throw new InvalidOperationException(nameof(_locationService));
        }

        public async void RefreshData()
        {
            await GetCurrentLocationArea();
            await GetCurrentWeather();
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
                        var uri = $"https://api.openweathermap.org/data/2.5/onecall?appid={Constants.OpenWeatherMap_Key}&lat={position.Latitude}&lon={position.Longitude}";

                        var resp = await _apiService.GetAsync(uri);

                        if (resp != null)
                        {
                            // resolve here, data is present but null deserialization
                            OneCallData = JsonConvert.DeserializeObject<OneCallDto>(resp);
                            Console.WriteLine(OneCallData.Timezone);
                            Console.WriteLine(OneCallData.Current.Uvi);
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
