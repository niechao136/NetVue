using Npgsql;

namespace DAL
{
    public class PostgreSQLCommon
    {
        public static NpgsqlConnection OpenConnection()
        {
            const string path = "Server=139.196.41.110;Port=5432;UserId=postgres;Password=158818;Database=net_vue;";
            NpgsqlConnection connection = new NpgsqlConnection(path);
            connection.Open();
            return connection;
        }
    }
}