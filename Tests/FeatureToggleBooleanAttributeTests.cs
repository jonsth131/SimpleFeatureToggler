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
    }

    [FeatureOn(false)]
    public class FalseBooleanDummy
    {
    }

    [FeatureOn(true)]
    public class TrueBooleanDummy
    {
    }
}
