using System.Reflection;
using SimpleFeatureToggler.Attributes;
using SimpleFeatureToggler.Util;

namespace SimpleFeatureToggler.Extensions
{
    public static class CheckToggleExtension
    {
        public static bool IsFeatureEnabled(this object obj)
        {
            var type = obj.GetType();
            return type.BaseType == typeof(DevEnvToggle) ? CheckDevEnvToggle(obj) : CheckIfAttributeIsEnabled(type);
        }

        private static bool CheckIfAttributeIsEnabled(MemberInfo type)
        {
            var attribute = type.GetCustomAttribute<FeatureOnAttribute>();
            return attribute == null || attribute.IsEnabled();
        }

        private static bool CheckDevEnvToggle(object obj)
        {
            var toggle = obj as DevEnvToggle;
            return toggle != null && toggle.IsDevEnv();
        }
    }
}
