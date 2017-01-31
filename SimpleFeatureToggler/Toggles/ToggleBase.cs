using System.Configuration;

namespace SimpleFeatureToggler.Toggles
{
    public abstract class ToggleBase
    {
        protected T GetSetting<T>(string postfix)
        {
            var name = GetType().Name + "." + postfix;
            var reader = new AppSettingsReader();
            T value;
            try
            {
                value = (T)reader.GetValue(name, typeof(T));
            }
            catch
            {
                return default(T);
            }
            return value;
        }
    }
}
