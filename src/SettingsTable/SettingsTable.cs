using System;
using System.Collections.Generic;

namespace SettingsTable
{
    public class SettingsTable<TKey, TValue> : IClearable where TValue : class
    {
        public List<SettingsTableVersion<TKey, TValue>> Versions { get; } = new List<SettingsTableVersion<TKey, TValue>>();

        public void AddVersion(SettingsTableVersion<TKey, TValue> version)
        {
            if (version == null)
            {
                throw new ArgumentNullException(nameof(version));
            }

            Versions.Add(version);
        }

        /// <summary>
        /// Remove all versions from the table
        /// </summary>
        public void Clear() => Versions.Clear();
    }
}
