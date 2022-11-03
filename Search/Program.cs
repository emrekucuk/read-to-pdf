

System.Console.Write("Aranacak Kelime/Cumle Giriniz:");
string line = System.Console.ReadLine();

// System.Console.WriteLine(line);
var dbContext = new Search.Databases.DbContext();

dbContext.GetAllSearchableContent(line);