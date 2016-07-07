using System;

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
            if (FeatureOn)
            {
                return FeatureOn;
            }
            if (string.IsNullOrEmpty(StartDate) && string.IsNullOrEmpty(EndDate))
            {
                return FeatureOn;
            }
            if (string.IsNullOrEmpty(StartDate))
            {
                return !IsEndDateReached();
            }
            if (string.IsNullOrEmpty(EndDate))
            {
                return IsStartDateReached();
            }
            return IsDatesInRange();
        }

        private bool IsDatesInRange()
        {
            return IsStartDateReached() && !IsEndDateReached();
        }

        private bool IsStartDateReached()
        {
            var dt = DateTime.Parse(StartDate);
            return dt <= DateTime.Now;
        }

        private bool IsEndDateReached()
        {
            var dt = DateTime.Parse(EndDate);
            return dt <= DateTime.Now;
        }
    }
}