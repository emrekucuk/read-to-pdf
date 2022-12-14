using Npgsql;

namespace PgFullTextSearch.Databases;

public class DbContext
{
    public void GetAllSearchableContent(string searchText)
    {
        searchText = searchText.Trim().Replace(" ", " | ");

        using (var connection = new NpgsqlConnection(Definitions.ConnectionString))
        {
            connection.Open();

            // using (var command = new NpgsqlCommand("SELECT id, filename FROM searchablecontents  WHERE tokens @@ to_tsquery(@s)", connection))
            using (var command = new NpgsqlCommand("SELECT id, filename, ts_rank_cd(tokens, query) AS rank FROM searchablecontents, to_tsquery('Turkish',@s) query WHERE query @@ tokens ORDER BY rank DESC", connection))
            {
                command.Parameters.AddWithValue("s", searchText);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    System.Console.WriteLine($"Rank: {reader.GetDouble(2).ToString("0.##")} - Id: {reader.GetInt32(0).ToString()} - Path: {reader.GetString(1)}");
                }
                reader.Close();
            }
        }
    }
}