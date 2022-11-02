
using System.Data.Common;

// DbConnection connection = Databases.DbContext.Connection();

// System.Console.WriteLine(connection.State);
// connection.Open();
// System.Console.WriteLine(connection.State);

var dbContext = new Databases.DbContext();

var filePaths = FileUtilites.FileUtilities.GetAllFileFromDirectory("pdfs");

filePaths.ForEach((filePath) =>
{
    System.Console.WriteLine(filePath);
    var pageText = PdfUtilities.PdfUtilities.ReadFile(filePath);

    dbContext.InstertData(filePath, pageText);

    // dbContext.GetAllCourses();
    // System.Console.WriteLine(pageText);
    System.Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------");
});


