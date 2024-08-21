namespace NeilvynApp.Core.Helpers
{
    public static class StringLongTimHelper
    {
        public static DateTime ToLocalDateTime(this string str)
        {
            bool success = long.TryParse(str, out long number);

            if (success)
            {
                DateTime utc = DateTimeOffset.FromUnixTimeSeconds(number).UtcDateTime;
                DateTime local = utc.ToLocalTime();
                
                return local;
            }

            return default(DateTime);
        }
    }
}
