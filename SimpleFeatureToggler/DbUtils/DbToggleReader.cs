namespace SimpleFeatureToggler.DbUtils
{
    internal class DbToggleReader
    {
        private readonly IDbReader _dbReader;

        public DbToggleReader(string connectionString) : this(new DbReader(connectionString))
        {
        }

        public DbToggleReader(IDbReader dbReader)
        {
            _dbReader = dbReader;
        }

        public bool IsToggleEnabled(string toggle)
        {
            return _dbReader.Read(toggle);
        }
    }
}
