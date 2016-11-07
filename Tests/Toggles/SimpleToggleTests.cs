using FluentAssertions;
using NUnit.Framework;
using SimpleFeatureToggler.Toggles;

namespace Tests.Toggles
{
    [TestFixture]
    public class SimpleToggleTests
    {
        [Test]
        public void IsEnabled_AppSettingTrue_ShouldReturnTrue()
        {
            var simpleToggleDummy = new SimpleToggleTrueDummy();

            var isEnabled = simpleToggleDummy.IsEnabled();

            isEnabled.Should().BeTrue();
        }

        [Test]
        public void IsEnabled_AppSettingFalse_ShouldReturnFalse()
        {
            var simpleToggleDummy = new SimpleToggleFalseDummy();

            var isEnabled = simpleToggleDummy.IsEnabled();

            isEnabled.Should().BeFalse();
        }

        [Test]
        public void IsEnabled_NoAppSetting_ShouldReturnFalse()
        {
            var simpleToggleDummy = new SimpleToggleDummy();

            var isEnabled = simpleToggleDummy.IsEnabled();

            isEnabled.Should().BeFalse();
        }

        public class SimpleToggleDummy : SimpleToggle
        {
        }

        public class SimpleToggleFalseDummy : SimpleToggle
        {
        }

        public class SimpleToggleTrueDummy : SimpleToggle
        {
        }
    }
}
