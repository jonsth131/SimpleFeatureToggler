using FluentAssertions;
using NUnit.Framework;
using SimpleFeatureToggler.Attributes;
using SimpleFeatureToggler.Extensions;
using SimpleFeatureToggler.Util;

namespace Tests
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void TestObjectWithNoAttribute()
        {
            var dummy = new EmptyClass();

            var isFeatureEnabled = dummy.IsFeatureEnabled();

            isFeatureEnabled.Should().BeTrue();
        }

        [Test]
        public void TestDevEnvToggle()
        {
            var dummy = new ExtensionTestClass();

            var isFeatureEnabled = dummy.IsFeatureEnabled();

            isFeatureEnabled.Should().BeTrue();
        }
    }

    [FeatureOn(false)]
    public class ExtensionTestClass : DevEnvToggle
    {
    }

    public class EmptyClass
    {
    }
}
