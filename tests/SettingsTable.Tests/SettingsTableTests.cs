using System;
using Xunit;

namespace SettingsTable.Tests
{
    public class SettingsTableTests
    {
        #region AddVersion tests

        [Fact]
        public void AddVersionShouldThrowExceptionWhenNullArgumentIsProvided()
        {
            var table = new SettingsTable<string,string>();

            Assert.NotNull(table.Versions);
            Assert.Empty(table.Versions);

            Assert.Throws<ArgumentNullException>(() =>
            {
                table.AddVersion(null);
            });
        }

        [Fact]
        public void AddVersionShouldAddToVersionList()
        {
            var table = new SettingsTable<string, string>();

            Assert.NotNull(table.Versions);
            Assert.Empty(table.Versions);

            var version = new SettingsTableVersion<string, string>();

            table.AddVersion(version);

            Assert.NotEmpty(table.Versions);
            Assert.Collection(table.Versions, v => Assert.Equal(v, version));
        }

        #endregion

        #region Clear tests

        [Fact]
        public void ClearShouldRemoveAllVersionsFromTable()
        {
            var table = new SettingsTable<string, string>();
            table.AddVersion(new SettingsTableVersion<string, string>());

            Assert.NotEmpty(table.Versions);

            table.Clear();

            Assert.Empty(table.Versions);
        }

        #endregion

        #region EqualsTests

        [Fact]
        public void EqualsShouldReturnFalseWhenComparingToNull()
        {
            var table = new SettingsTable<string, string>();

            Assert.False(table.Equals(null));
        }

        [Fact]
        public void EqualsShouldReturnFalseWhenTypesAreNotEqual()
        {
            var table = new SettingsTable<string, string>();

            Assert.False(table.Equals(new object()));
        }

        [Fact]
        public void EqualsShouldReturnTrueWhenReferencesAreEqual()
        {
            var table = new SettingsTable<string, string>();
            var otherTable = table;

            Assert.True(table.Equals(otherTable));
        }

        [Fact]
        public void EqualsShouldReturnTrueWhenAllVersionsAreEqualInTwoTables()
        {
            var version = new SettingsTableVersion<string,string>();

            var table = new SettingsTable<string, string>();
            var otherTable = new SettingsTable<string, string>();

            table.AddVersion(version);
            otherTable.AddVersion(version);

            Assert.True(table.Equals(otherTable));
        }

        [Fact]
        public void EqualsShouldReturnFalseWhenAllVersionsAreEqualInTwoTables()
        {
            var version = new SettingsTableVersion<string, string>();
            var anotherVersion = new SettingsTableVersion<string, string>();

            var table = new SettingsTable<string, string>();
            var otherTable = new SettingsTable<string, string>();

            table.AddVersion(version);
            otherTable.AddVersion(anotherVersion);

            Assert.False(table.Equals(otherTable));
        }

        #endregion

        #region GetHashCodeTests

        [Fact]
        public void GetHashCodeShouldReturnHashCodeOfAllVersions()
        {
            var table = new SettingsTable<string, string>();
            table.AddVersion(new SettingsTableVersion<string, string>());

            int versionsHashCode = table.Versions.GetHashCode();

            Assert.Equal(versionsHashCode, table.GetHashCode());
        }

        #endregion
    }
}
