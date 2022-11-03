using System.Data.Common;

// DbConnection connection = Databases.DbContext.Connection();

// System.Console.WriteLine(connection.State);
// connection.Open();
// System.Console.WriteLine(connection.State);

var dbContext = new ContentImporter.Databases.DbContext();

var filePaths = ContentImporter.FileUtilites.FileUtilities.GetAllFileFromDirectory("pdfs");

filePaths.ForEach((filePath) =>
{
    System.Console.WriteLine(filePath);
    var pageText = ContentImporter.PdfUtilities.PdfUtilities.ReadFile(filePath);

    dbContext.InstertData(filePath, pageText);

    // dbContext.GetAllCurrencies();
    // System.Console.WriteLine(pageText);
    System.Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------");
});
