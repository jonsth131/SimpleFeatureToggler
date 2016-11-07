using System;
using System.Configuration;

namespace SimpleFeatureToggler.Toggles
{
    public abstract class DateToggle
    {
        public bool IsEnabled()
        {
            var startDate = GetDate("StartDate");
            var endDate = GetDate("EndDate");
            return IsFeatureEnabledBasedOnDates(startDate, endDate);
        }

        private string GetDate(string postfix)
        {
            var name = GetType().Name + "." + postfix;
            var reader = new AppSettingsReader();
            string date;
            try
            {
                date = (string) reader.GetValue(name, typeof(string));
            }
            catch
            {
                return null;
            }
            return date;
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
