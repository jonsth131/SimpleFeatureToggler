namespace SimpleFeatureToggler.Toggles
{
    public abstract class SimpleToggle : ToggleBase
    {
        public bool IsEnabled()
        {
            var enabled = GetSetting<bool>("IsEnabled");
            return enabled;
        }
    }
}
