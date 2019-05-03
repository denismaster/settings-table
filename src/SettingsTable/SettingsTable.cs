using System;
using System.Collections.Generic;
using System.Linq;

namespace SettingsTable
{
    public class SettingsTable<TKey, TValue> : IClearable, IEquatable<SettingsTable<TKey,TValue>> 
        where TValue : class
    {
        public List<SettingsTableVersion<TKey, TValue>> Versions { get; } = new List<SettingsTableVersion<TKey, TValue>>();

        /// <summary>
        /// Add new version to the table
        /// </summary>
        /// <param name="version">A new SettingsTableVersion, which should be added to the table</param>
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

        public bool Equals(SettingsTable<TKey, TValue> other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other)) return true;

            return Versions.SequenceEqual(other.Versions);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            return Equals((SettingsTable<TKey, TValue>)obj);
        }

        public override int GetHashCode()
        {
            return Versions.GetHashCode();
        }
    }
}
