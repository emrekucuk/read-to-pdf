

System.Console.Write("Aranacak Kelime/Cumle Giriniz:");
string line = System.Console.ReadLine();

// System.Console.WriteLine(line);
var dbContext = new PgFullTextSearch.Databases.DbContext();

dbContext.GetAllSearchableContent(line);