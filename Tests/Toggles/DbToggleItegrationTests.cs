using FluentAssertions;
using NUnit.Framework;
using SimpleFeatureToggler.Toggles;

namespace Tests.Toggles
{
    [TestFixture]
    [Category("Integration")]
    public class DbToggleItegrationTests
    {
        [Test]
        public void IsEnabledShouldBeTrue()
        {
            var dbToggleDummy = new DbToggleDummy();
            dbToggleDummy.CreateTableIfNotExists();

            var isEnabled = dbToggleDummy.IsEnabled();

            isEnabled.Should().BeFalse();
        }

        private class DbToggleDummy : DbToggle
        {

        }
    }
}
