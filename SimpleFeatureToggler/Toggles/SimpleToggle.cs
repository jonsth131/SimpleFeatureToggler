using System.Configuration;

namespace SimpleFeatureToggler.Toggles
{
    public abstract class SimpleToggle
    {
        public bool IsEnabled()
        {
            var name = GetType().Name + ".IsEnabled";
            var reader = new AppSettingsReader();
            bool enabled;
            try
            {
                enabled = (bool)reader.GetValue(name, typeof(bool));
            }
            catch
            {
                return false;
            }
            return enabled;
        }
    }
}
