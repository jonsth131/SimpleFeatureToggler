using System.Configuration;

namespace SimpleFeatureToggler.Util
{
    public abstract class DevEnvToggle
    {
        public bool IsDevEnv()
        {
            var reader = new AppSettingsReader();
            bool devEnv;
            try
            {
                devEnv = (bool) reader.GetValue("dev-env", typeof(bool));
            }
            catch
            {
                return false;
            }
            return devEnv;
        }
    }
}
