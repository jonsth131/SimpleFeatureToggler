using System.Data.SqlClient;

namespace Tests.Utils
{
    public static class DbUtil
    {
        public static void DropFeatureTogglesTable()
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["FeatureToggler"].ConnectionString;

            using (var connection = new SqlConnection(connString))
            using (var command = new SqlCommand())
            {
                connection.Open();

                command.Connection = connection;

                var dataTable = connection.GetSchema("TABLES", new[] { null, null, "FeatureToggles" });

                if (dataTable.Rows.Count <= 0) return;
                command.CommandText = @"DROP TABLE [dbo].[FeatureToggles]";
                command.ExecuteNonQuery();
            }
        }
    }
}