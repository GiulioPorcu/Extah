using System.Data.SqlClient;

namespace Extah
{
    /// <summary>
    /// 
    /// </summary>
    public static class SqlConnectionExtensions
    {
        /// <summary>
        /// Returns a collection of all database instances using the provided connection
        /// The connection here is special in that it only requires a server name and user credentials since it talks to the master tables
        /// </summary>
        /// <param name="connection"></param>
        public static async Task<List<string>> GetDatabaseListAsync(this SqlConnection connection)
        {
            return await Task.Run(() =>
            {
                List<string> list = new List<string>();

                const string query = @"SELECT name FROM sys.databases WHERE HAS_DBACCESS(name) = 1 
                               AND CASE WHEN state_desc = 'ONLINE' 
                               THEN OBJECT_ID(QUOTENAME(name) + '.[sysdba].[VIRTUALFILESYSTEM]', 'U') END IS NOT NULL";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            list.Add(dataReader[0].ToString());
                        }
                    }
                }

                // optional
                list.Sort();

                return list;
            });
        }
    }
}
