namespace NeilvynApp.Core.Location
{
	public interface ILocationService
	{
		public Task<Location?> GetCurrentLocationAsync();
	}
}