using FluentAssertions;
using NUnit.Framework;
using SimpleFeatureToggler.Attributes;
using SimpleFeatureToggler.Extensions;

namespace Tests
{
    [TestFixture]
    public class FeatureToggleEndDateAttributeTest
    {
        [Test]
        public void TestPassedEndDate()
        {
            var dummy = new FalseEndDateDummy();

            var isFeatureEnabled = dummy.IsFeatureEnabled();

            isFeatureEnabled.Should().BeFalse();
        }

        [Test]
        public void TestFutureEndDate()
        {
            var dummy = new TrueEndDateDummy();

            var isFeatureEnabled = dummy.IsFeatureEnabled();

            isFeatureEnabled.Should().BeTrue();
        }

        [FeatureOn(EndDate = "1900-01-01")]
        private class FalseEndDateDummy
        {
        }

        [FeatureOn(EndDate = "2900-01-01")]
        private class TrueEndDateDummy
        {
        }
    }
}
