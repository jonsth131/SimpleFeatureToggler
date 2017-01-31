using System.Data;
using System.Data.SqlClient;

namespace SimpleFeatureToggler.DbUtils
{
    internal class DbReadCommands
    {
        internal static SqlDataReader SelectToggleValueCommand(string toggle, SqlCommand command)
        {
            command.CommandText = @"SELECT Id, Toggle FROM [dbo].[FeatureToggles] WHERE ToggleName = @ToggleName";
            command.Parameters.AddWithValue("@ToggleName", toggle);

            return command.ExecuteReader();
        }

        internal static DataTable GetFeatureToggleTable(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.GetSchema("TABLES", new[] { null, null, "FeatureToggles" });
            }
        }
    }
}