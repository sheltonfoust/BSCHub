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


        public static DateOnly AddDaysSafe(this DateOnly dateOnly, int days)
        {
            var maxValue = DateOnly.MaxValue.DayNumber - dateOnly.DayNumber;
            var minValue = DateOnly.MinValue.DayNumber - dateOnly.DayNumber;
            return dateOnly.AddDays(days > maxValue ? maxValue : days < minValue ? minValue : days);
        }

    }
}
