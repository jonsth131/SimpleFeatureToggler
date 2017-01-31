using SimpleFeatureToggler.DbUtils;

namespace SimpleFeatureToggler.Toggles
{
    public abstract class DbToggle
    {
        public bool IsEnabled()
        {
            var connectionString = ReadConnectionString();
            var dbToggleReader = new DbToggleReader(connectionString);
            return dbToggleReader.IsToggleEnabled(GetType().Name + ".IsEnabled");
        }

        public void CreateTableIfNotExists()
        {
            var connectionString = ReadConnectionString();
            var dbWriter = new DbWriter(connectionString);
            dbWriter.CreateTableIfNotExists();
        }

        public void SetToggle(bool toggle)
        {
            var toggleName = GetType().Name + ".IsEnabled";
            var connectionString = ReadConnectionString();
            var dbWriter = new DbWriter(connectionString);
            dbWriter.SetToggle(toggle, toggleName);
        }

        private static string ReadConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["FeatureToggler"].ConnectionString;
        }
    }
}
