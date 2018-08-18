using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SettingsTable.Tests
{
    public class SettingsTableTests
    {
        #region AddVersion tests

        [Fact]
        public void AddVersionShouldAddToVersionList()
        {
            var table = new SettingsTable<string,string>();

            Assert.NotNull(table.Versions);
            Assert.Empty(table.Versions);

            var version = new SettingsTableVersion<string, string>();

            table.AddVersion(version);

            Assert.NotEmpty(table.Versions);
            Assert.Collection(table.Versions, v => Assert.Equal(v, version));
        }

        #endregion
    }
}
