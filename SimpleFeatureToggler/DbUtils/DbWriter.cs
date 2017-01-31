using System.Data.SqlClient;

namespace SimpleFeatureToggler.DbUtils
{
    internal interface IDbWriter
    {
        void CreateTableIfNotExists();
    }

    internal class DbWriter : IDbWriter
    {
        private readonly string _connectionString;

        public DbWriter(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateTableIfNotExists()
        {
            if (TableExist() == false)
            {
                DbWriteCommands.CreateTable(_connectionString);
            }
        }

        private bool TableExist()
        {
            var dTable = DbReadCommands.GetFeatureToggleTable(_connectionString);

            return dTable.Rows.Count > 0;
        }

        public void SetToggle(bool toggle, string toggleName)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();

                command.Connection = connection;

                var reader = DbReadCommands.SelectToggleValueCommand(toggleName, command);

                if (reader.HasRows == false)
                {
                    DbWriteCommands.CreateToggleRow(toggleName, toggle, _connectionString);
                }
                else
                {
                    DbWriteCommands.UpdateToggleRow(toggleName, toggle, _connectionString);
                }
            }
        }
    }
}
