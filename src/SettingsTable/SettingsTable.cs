using System.Collections.Generic;

namespace SettingsTable
{
    public class SettingsTable<TKey, TValue> : IClearable where TValue : class
    {
        public List<SettingsTableVersion<TKey, TValue>> Versions { get; private set; } = new List<SettingsTableVersion<TKey, TValue>>();

        public void AddVersion(SettingsTableVersion<TKey, TValue> version)
        {
            Versions.Add(version);
        }

        public void Clear()
        {
            Versions.Clear();
        }
    }
}
