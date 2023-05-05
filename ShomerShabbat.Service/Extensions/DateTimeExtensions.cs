namespace ShomerShabbat.Service;

public static class DateTimeExtensions
{
    public static bool IsNohalShabbat(this DateTime dateTime)
    {
        if (dateTime.DayOfWeek == DayOfWeek.Friday)
        {
            return dateTime.Hour > 15;
        }

        if (dateTime.DayOfWeek == DayOfWeek.Saturday)
        {
            return dateTime.Hour < 20;
        }
        return false;
    }
}