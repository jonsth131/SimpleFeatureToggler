using FluentAssertions;
using NUnit.Framework;
using SimpleFeatureToggler.Toggles;

namespace Tests.Toggles
{
    [TestFixture]
    public class DateToggleTests
    {
        [Test]
        public void TestPassedDate()
        {
            var dummy = new TrueDateTimeDummy();

            var isFeatureEnabled = dummy.IsEnabled();

            isFeatureEnabled.Should().BeTrue();
        }

        [Test]
        public void TestFutureDate()
        {
            var dummy = new FalseDateTimeDummy();

            var isFeatureEnabled = dummy.IsEnabled();

            isFeatureEnabled.Should().BeFalse();
        }

        [Test]
        public void TestPassedStartDateAndFutureEndDate()
        {
            var dummy = new TrueStartAndEndDateTimeDummy();

            var isFeatureEnabled = dummy.IsEnabled();

            isFeatureEnabled.Should().BeTrue();
        }

        [Test]
        public void TestPassedStartDateAndPassedEndDate()
        {
            var dummy = new FalseStartAndEndDateTimeDummy();

            var isFeatureEnabled = dummy.IsEnabled();

            isFeatureEnabled.Should().BeFalse();
        }

        [Test]
        public void TestFutureStartDateAndFutureEndDate()
        {
            var dummy = new FalseFutureStartAndEndDateTimeDummy();

            var isFeatureEnabled = dummy.IsEnabled();

            isFeatureEnabled.Should().BeFalse();
        }

        private class TrueDateTimeDummy : DateToggle
        {
        }

        private class FalseDateTimeDummy : DateToggle
        {
        }

        private class TrueStartAndEndDateTimeDummy : DateToggle
        {
        }

        private class FalseStartAndEndDateTimeDummy : DateToggle
        {
        }

        private class FalseFutureStartAndEndDateTimeDummy : DateToggle
        {
        }
    }
}
