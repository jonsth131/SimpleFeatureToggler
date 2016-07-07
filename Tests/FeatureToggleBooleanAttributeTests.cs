using FluentAssertions;
using NUnit.Framework;
using SimpleFeatureToggler.Attributes;
using SimpleFeatureToggler.Extensions;

namespace Tests
{
    [TestFixture]
    public class FeatureToggleBooleanAttributeTests
    {
        [Test]
        public void TestFeatureOnAttributeTrue()
        {
            var dummy = new TrueBooleanDummy();

            var isFeatureEnabled = dummy.IsFeatureEnabled();

            isFeatureEnabled.Should().BeTrue();
        }

        [Test]
        public void TestFeatureOnAttributeFalse()
        {
            var dummy = new FalseBooleanDummy();

            var isFeatureEnabled = dummy.IsFeatureEnabled();

            isFeatureEnabled.Should().BeFalse();
        }

        [Test]
        public void TestFeatureOnAttributeFutureEndDate()
        {
            var dummy = new TrueBooleanFutureEndDateDummy();

            var isFeatureEnabled = dummy.IsFeatureEnabled();

            isFeatureEnabled.Should().BeTrue();
        }

        [Test]
        public void TestFeatureOnAttributePassedEndDate()
        {
            var dummy = new TrueBooleanPassedEndDateDummy();

            var isFeatureEnabled = dummy.IsFeatureEnabled();

            isFeatureEnabled.Should().BeTrue();
        }

        [Test]
        public void TestFalseFeatureOnAttributeFutureEndDate()
        {
            var dummy = new FalseBooleanPassedEndDateDummy();

            var isFeatureEnabled = dummy.IsFeatureEnabled();

            isFeatureEnabled.Should().BeFalse();
        }

        [Test]
        public void TestFalseFeatureOnAttributePassedEndDate()
        {
            var dummy = new FalseooleanFutureEndDateDummy();

            var isFeatureEnabled = dummy.IsFeatureEnabled();

            isFeatureEnabled.Should().BeTrue();
        }

        [FeatureOn(FeatureOn = false)]
        private class FalseBooleanDummy
        {
        }

        [FeatureOn(FeatureOn = true)]
        private class TrueBooleanDummy
        {
        }

        [FeatureOn(FeatureOn = true, EndDate = "1900-01-01")]
        private class TrueBooleanPassedEndDateDummy
        {
        }

        [FeatureOn(FeatureOn = true, EndDate = "2900-01-01")]
        private class TrueBooleanFutureEndDateDummy
        {
        }

        [FeatureOn(FeatureOn = false, EndDate = "1900-01-01")]
        private class FalseBooleanPassedEndDateDummy
        {
        }

        [FeatureOn(FeatureOn = false, EndDate = "2900-01-01")]
        private class FalseooleanFutureEndDateDummy
        {
        }
    }
}
