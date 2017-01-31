using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using SimpleFeatureToggler.DbUtils;

namespace Tests.DbUtil
{
    [TestFixture]
    public class DbToggleReaderTests
    {
        private const string FalseToggle = "false";
        private const string TrueToggle = "true";
        private DbToggleReader _dbToggleReader;

        [SetUp]
        public void SetUp()
        {
            var dbReader = Substitute.For<IDbReader>();
            dbReader.Read(TrueToggle).Returns(true);
            dbReader.Read(FalseToggle).Returns(false);
            _dbToggleReader = new DbToggleReader(dbReader);
        }

        [Test]
        public void IsToggleEnabledShouldReturnTrue()
        {
            var isToggleEnabled = _dbToggleReader.IsToggleEnabled(TrueToggle);

            isToggleEnabled.Should().BeTrue();
        }

        [Test]
        public void IsToggleEnabledShouldReturnFalse()
        {
            var isToggleEnabled = _dbToggleReader.IsToggleEnabled(FalseToggle);

            isToggleEnabled.Should().BeFalse();
        }
    }
}
