using System.Data.Common;

// var definitions = new Definitions();
// DbConnection connection = definitions.Connection();

// System.Console.WriteLine(connection.State);
// connection.Open();
// System.Console.WriteLine(connection.State);

var dbContext = new PdfOperations.Databases.DbContext();

var filePaths = PdfOperations.FileUtilites.FileUtilities.GetAllFileFromDirectory("pdfs");

filePaths.ForEach((filePath) =>
{
    System.Console.WriteLine(filePath);
    var pageText = PdfOperations.PdfUtilities.PdfUtilities.ReadFile(filePath);

    dbContext.InstertData(filePath, pageText);

    // dbContext.GetAllCurrencies();
    // System.Console.WriteLine(pageText);
    System.Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------");
});
