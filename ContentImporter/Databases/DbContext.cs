using System.Data.Common;
using Npgsql;

namespace ContentImporter.Databases;

public class DbContext
{
    // public static string connectionString = "User ID=postgres;Password=password;Server=localhost;Port=5432;Database=currency-exchange;Integrated Security=true;Pooling=true;";
    public static string connectionString = "User ID=postgres;Password=EeDReSw8cX5@Ceg&+JTst3FFgeCfPRBJNYF@X!N4zq2vB4F*;Server=141.98.1.177;Port=5432;Database=currency-exchange;Integrated Security=true;Pooling=true;";

    public DbConnection Connection()
    {

        var connection = new NpgsqlConnection(connectionString);
        return connection;
    }

    public void InstertData(string filePath, string pageText)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            Console.Out.WriteLine("Opening connection");
            connection.Open();

            var createCommand = new NpgsqlCommand("INSERT INTO searchablecontents (bookid, content, filename) VALUES (@b, @c,@f) returning id", connection);

            var guid = Guid.NewGuid();
            createCommand.Parameters.AddWithValue("b", guid);
            createCommand.Parameters.AddWithValue("c", pageText);
            createCommand.Parameters.AddWithValue("f", filePath);

            var id = createCommand.ExecuteScalar();

            System.Console.WriteLine($"----------Insert----------");

            var updateCommand = new NpgsqlCommand($"UPDATE searchablecontents s1 SET tokens = to_tsvector('Turkish', s1.content) WHERE id = {id}", connection);

            updateCommand.ExecuteNonQuery();
            System.Console.WriteLine($"----------Update----------");
        }
    }


    // public void GetAllCurruncies()
    // {
    //     var connection = Connection();
    //     connection.Open();

    //     DbCommand command = connection.CreateCommand();

    //     command.CommandText = "select * from \"Curruncies\"";

    //     var reader = command.ExecuteReader();
    //     while (reader.Read())
    //     {
    //         Console.WriteLine(
    //             string.Format($"Reading from table={reader.GetString(1)}"));
    //     }
    //     reader.Close();
    // }


}