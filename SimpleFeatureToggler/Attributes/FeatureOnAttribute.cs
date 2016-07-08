using System;
using SimpleFeatureToggler.Util;

namespace SimpleFeatureToggler.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class FeatureOnAttribute : Attribute
    {
        public bool FeatureOn { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public bool IsEnabled()
        {
            if (FeatureOn || DatesEntered())
            {
                return FeatureOn;
            }
            return DateToggleHelper.IsFeatureEnabledBasedOnDates(StartDate, EndDate);
        }

        private bool DatesEntered()
        {
            return string.IsNullOrEmpty(StartDate) && string.IsNullOrEmpty(EndDate);
        }
    }
}