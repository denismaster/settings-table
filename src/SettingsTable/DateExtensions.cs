using System;

namespace SettingsTable
{
    public static class DateExtensions
    {
        public static bool ContainsDate(this IDateInterval interval, DateTime? date)
        {
            if (date == null)
                return false;

            var startDate = interval.StartDate;
            var endDate = interval.EndDate;

            return (startDate == null || date >= startDate) && (endDate == null || date <= endDate);
        }
    }
}
