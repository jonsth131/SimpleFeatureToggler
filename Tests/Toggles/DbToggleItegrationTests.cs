using FluentAssertions;
using NUnit.Framework;
using SimpleFeatureToggler.Toggles;

namespace Tests.Toggles
{
    [TestFixture]
    [Category("Integration")]
    public class DbToggleItegrationTests
    {
        [SetUp]
        public void SetUp()
        {
            Utils.DbUtil.DropFeatureTogglesTable();
        }

        [Test]
        public void IsEnabled_NoInitToggle_CreatesNewTrueToggle()
        {
            var dbToggleDummy = new DbToggleDummy();
            dbToggleDummy.CreateTableIfNotExists();
            dbToggleDummy.SetToggle(true);

            var isEnabled = dbToggleDummy.IsEnabled();

            isEnabled.Should().BeTrue();
        }

        [Test]
        public void IsEnabled_FalseToggle_UpdatesToggleToTrue()
        {
            var dbToggleDummy = new DbToggleDummy();
            dbToggleDummy.CreateTableIfNotExists();
            dbToggleDummy.IsEnabled();
            dbToggleDummy.SetToggle(true);

            var isEnabled = dbToggleDummy.IsEnabled();

            isEnabled.Should().BeTrue();
        }

        private class DbToggleDummy : DbToggle
        {

        }
    }
}
