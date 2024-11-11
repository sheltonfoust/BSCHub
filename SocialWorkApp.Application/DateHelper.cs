namespace BSCHub.Application
{
    public static class DateHelper
    {
        public static DateOnly GetToday()   
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time");
            DateTime localTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, timeZone);
            return DateOnly.FromDateTime(localTime);
        }

    }
}
