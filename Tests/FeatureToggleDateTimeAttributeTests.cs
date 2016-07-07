using FluentAssertions;
using NUnit.Framework;
using SimpleFeatureToggler.Attributes;
using SimpleFeatureToggler.Extensions;

namespace Tests
{
    [TestFixture]
    public class FeatureToggleDateTimeAttributeTests
    {
        [Test]
        public void TestPassedDate()
        {
            var dummy = new TrueDateTimeDummy();

            var isFeatureEnabled = dummy.IsFeatureEnabled();

            isFeatureEnabled.Should().BeTrue();
        }

        [Test]
        public void TestFutureDate()
        {
            var dummy = new FalseDateTimeDummy();

            var isFeatureEnabled = dummy.IsFeatureEnabled();

            isFeatureEnabled.Should().BeFalse();
        }

        [Test]
        public void TestPassedStartDateAndFutureEndDate()
        {
            var dummy = new TrueStartAndEndDateTimeDummy();

            var isFeatureEnabled = dummy.IsFeatureEnabled();

            isFeatureEnabled.Should().BeTrue();
        }

        [Test]
        public void TestPassedStartDateAndPassedEndDate()
        {
            var dummy = new FalseStartAndEndDateTimeDummy();

            var isFeatureEnabled = dummy.IsFeatureEnabled();

            isFeatureEnabled.Should().BeFalse();
        }

        [Test]
        public void TestFutureStartDateAndFutureEndDate()
        {
            var dummy = new FalseFutureStartAndEndDateTimeDummy();

            var isFeatureEnabled = dummy.IsFeatureEnabled();

            isFeatureEnabled.Should().BeFalse();
        }

        [FeatureOn(StartDate = "1900-01-01")]
        private class TrueDateTimeDummy
        {
        }

        [FeatureOn(StartDate = "2900-01-01")]
        private class FalseDateTimeDummy
        {
        }

        [FeatureOn(StartDate = "1900-01-01", EndDate = "2900-01-01")]
        private class TrueStartAndEndDateTimeDummy
        {
        }

        [FeatureOn(StartDate = "1900-01-01", EndDate = "1900-10-01")]
        private class FalseStartAndEndDateTimeDummy
        {
        }

        [FeatureOn(StartDate = "2900-01-01", EndDate = "2900-10-01")]
        private class FalseFutureStartAndEndDateTimeDummy
        {
        }
    }
}
