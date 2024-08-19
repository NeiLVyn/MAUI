
namespace NeilvynApp.Core.Location
{
    public class LocationService : ILocationService
    {
        public LocationService()
        {
        }

        public async Task<Location?> GetCurrentLocationAsync()
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

                    return new Location { 
                        Latitude = latitude,
                        Longitude = longitude
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }
    }
}
