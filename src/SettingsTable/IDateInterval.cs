using System;

namespace SettingsTable
{
    public interface IDateInterval
    {
        DateTime? StartDate { get; }
        DateTime? EndDate { get; }
    }
}
