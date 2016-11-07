using System;

namespace SimpleFeatureToggler.Toggles
{
    public abstract class DateToggle : ToggleBase
    {
        public bool IsEnabled()
        {
            var startDate = GetSetting<string>("StartDate");
            var endDate = GetSetting<string>("EndDate");
            return IsFeatureEnabledBasedOnDates(startDate, endDate);
        }

        private static bool IsFeatureEnabledBasedOnDates(string startDate, string endDate)
        {
            if (string.IsNullOrEmpty(startDate))
            {
                return !IsEndDateReached(endDate);
            }
            if (string.IsNullOrEmpty(endDate))
            {
                return IsStartDateReached(startDate);
            }
            return IsDatesInRange(startDate, endDate);
        }

        private static bool IsDatesInRange(string startDate, string endDate)
        {
            return IsStartDateReached(startDate) && !IsEndDateReached(endDate);
        }

        private static bool IsStartDateReached(string startDate)
        {
            return CheckIfDateHasPassed(startDate);
        }

        private static bool IsEndDateReached(string endDate)
        {
            return CheckIfDateHasPassed(endDate);
        }

        private static bool CheckIfDateHasPassed(string date)
        {
            var dt = DateTime.Parse(date);
            return dt <= DateTime.Now;
        }
    }
}
