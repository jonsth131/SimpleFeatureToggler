using System;
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
        public void TestInvalidDate()
        {
            var dummy = new InvalidDateDummy();

            Action act = () => dummy.IsFeatureEnabled();

            act.ShouldThrow<FormatException>();
        }
    }

    [FeatureOn("1900-01-01")]
    public class TrueDateTimeDummy
    {
    }

    [FeatureOn("2900-01-01")]
    public class FalseDateTimeDummy
    {
    }

    [FeatureOn("INVALID DATE")]
    public class InvalidDateDummy
    {
    }
}
