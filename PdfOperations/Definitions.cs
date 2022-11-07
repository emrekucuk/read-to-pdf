using System.Data.Common;
using Npgsql;

public class Definitions
{
    public static string ConnectionString = "User ID=postgres;Password=password;Server=localhost;Port=5432;Database=currency-exchange;Integrated Security=true;Pooling=true;";

    public DbConnection Connection()
    {
        var connection = new NpgsqlConnection(ConnectionString);
        return connection;
    }
}