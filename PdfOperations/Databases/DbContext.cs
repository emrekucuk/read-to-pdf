using Npgsql;

namespace PdfOperations.Databases;

public class DbContext
{
    public void InstertData(string filePath, string pageText)
    {
        using (var connection = new NpgsqlConnection(Definitions.ConnectionString))
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