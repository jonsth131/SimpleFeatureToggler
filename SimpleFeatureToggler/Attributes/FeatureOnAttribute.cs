using System;

namespace SimpleFeatureToggler.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class FeatureOnAttribute : Attribute
    {
        public bool IsEnabled { get; }

        public FeatureOnAttribute(bool b)
        {
            IsEnabled = b;
        }

        public FeatureOnAttribute(string date)
        {
            var dt = DateTime.Parse(date);
            IsEnabled = dt <= DateTime.Now;
        }
    }
}