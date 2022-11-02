var filePaths = FileUtilites.FileUtilities.GetAllFileFromDirectory("pdfs");

filePaths.ForEach((filePath) =>
{
    System.Console.WriteLine(filePath);
    var pageText = PdfUtilities.PdfUtilities.ReadFile(filePath);

    System.Console.WriteLine(pageText);
    System.Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------");
});