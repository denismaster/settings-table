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
    }
}
