using System.Data;
using System.Data.SqlClient;

namespace SimpleFeatureToggler.DbUtils
{
    internal class DbWriteCommands
    {
        internal static void CreateTable(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();

                command.Connection = connection;

                CreateToggleTable(command);
                CreatePrimaryKey(command);
                SetLockEscalation(command);
            }
        }

        internal static void CreateToggleRow(string toggleName, string connectionString)
        {
            const bool toggle = false;
            CreateToggleRow(toggleName, toggle, connectionString);
        }

        internal static void CreateToggleRow(string toggleName, bool toggle, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();

                command.Connection = connection;

                command.CommandText = @"INSERT INTO [dbo].[FeatureToggles] (ToggleName, Toggle) VALUES (@ToggleName, @Toggle)";
                command.Parameters.AddWithValue("@ToggleName", toggleName);
                command.Parameters.AddWithValue("@Toggle", toggle);

                command.ExecuteNonQuery();
            }
        }

        internal static void UpdateToggleRow(string toggleName, bool toggle, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();

                command.Connection = connection;

                command.CommandText = @"UPDATE [dbo].[FeatureToggles] SET Toggle=@Toggle WHERE ToggleName=@ToggleName";
                command.Parameters.AddWithValue("@ToggleName", toggleName);
                command.Parameters.AddWithValue("@Toggle", toggle);

                command.ExecuteNonQuery();
            }
        }

        private static void SetLockEscalation(IDbCommand command)
        {
            command.CommandText = @"ALTER TABLE dbo.FeatureToggles SET (LOCK_ESCALATION = TABLE)";

            command.ExecuteNonQuery();
        }

        private static void CreatePrimaryKey(IDbCommand command)
        {
            command.CommandText =
                @"ALTER TABLE dbo.FeatureToggles ADD CONSTRAINT
	                        PK_FeatureToggles PRIMARY KEY CLUSTERED 
	                        (
	                        Id
	                        ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]";

            command.ExecuteNonQuery();
        }

        private static void CreateToggleTable(IDbCommand command)
        {
            command.CommandText =
                @"CREATE TABLE dbo.FeatureToggles
	                        (
	                        Id int NOT NULL IDENTITY (1, 1),
	                        ToggleName nvarchar(MAX) NOT NULL,
	                        Toggle bit NOT NULL
	                        )  ON [PRIMARY]
	                        TEXTIMAGE_ON [PRIMARY]";

            command.ExecuteNonQuery();
        }
    }
}