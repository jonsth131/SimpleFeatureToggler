using System.Data;
using System.Data.SqlClient;

namespace SimpleFeatureToggler.DbUtils
{
    internal interface IDbReader
    {
        bool Read(string toggle);
    }

    internal class DbReader : IDbReader
    {
        private readonly string _connectionString;

        public DbReader(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Read(string toggle)
        {
            try
            {
                return GetToggleValue(toggle);
            }
            catch
            {
                return false;
            }
        }

        private bool GetToggleValue(string toggle)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();

                command.Connection = connection;

                var reader = DbReadCommands.SelectToggleValueCommand(toggle, command);

                if (reader.HasRows == false)
                {
                    DbWriteCommands.CreateToggleRow(toggle, _connectionString);
                }
                
                return ReadToggleValue(reader);
            }
        }

        private static bool ReadToggleValue(IDataReader reader)
        {
            var toggle = false;

            while (reader.Read())
            {
                toggle = (bool) reader[1];
            }
            reader.Close();

            return toggle;
        }
    }
}
