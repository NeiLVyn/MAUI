namespace NeilvynApp.Core.Helpers
{
    public static class ServiceHelper
    {
        public static T GetService<T>() where T : class
        {
            var service = Current.GetService<T>();
            if (service == null)
            {
                throw new InvalidOperationException($"Service of type {typeof(T).Name} is not registered.");
            }
            return service;
        }

        private static IServiceProvider Current =>
            MauiProgram.CreateMauiApp().Services;
    }
}
