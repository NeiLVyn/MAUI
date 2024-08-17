using MySql.Data.MySqlClient;

namespace NeilvynApp
{
    public partial class MainPage : ContentPage
    {
        private IDispatcherTimer _timer;
        private string connectionString = "Server=sql12.freesqldatabase.com;Database=sql12723139;Uid=sql12723139;Pwd=7KlryHlb2e;";

        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            _timer = Dispatcher.CreateTimer();
            _timer.Interval = TimeSpan.FromMinutes(1);
            _timer.Tick += async (sender, e) => await GetCurrentLocationAsync();
            _timer.Start();
        }

        private async Task GetCurrentLocationAsync()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    double latitude = location.Latitude;
                    double longitude = location.Longitude;

                    Console.WriteLine($"------------------------------------------------------------");
                    Console.WriteLine($"Latitude: {latitude}, Longitude: {longitude}");
                    Console.WriteLine($"DeviceInfo: {DeviceInfo.Model}");

                    await SaveLocationAsync(latitude, longitude, DeviceInfo.Model);
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
            }
            catch (FeatureNotEnabledException fneEx)
            {
            }
            catch (PermissionException pEx)
            {
            }
            catch (Exception ex)
            {
            }
        }

        private async Task SaveLocationAsync(double latitude, double longitude, string deviceInfo)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();

                string query = "INSERT INTO locations (DeviceInfo, Latitude, Longitude, TimeStamp) VALUES (@DeviceInfo, @Latitude, @Longitude, @TimeStamp)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DeviceInfo", deviceInfo);
                    cmd.Parameters.AddWithValue("@Latitude", latitude);
                    cmd.Parameters.AddWithValue("@Longitude", longitude);
                    cmd.Parameters.AddWithValue("@TimeStamp", DateTime.Now.ToLocalTime());

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
