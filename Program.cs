using System.Text;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

List<string> filePaths = new List<string>();

string ReadFile(string pdfPath)
{
    var pageText = new StringBuilder();
    using (PdfDocument pdfDocument = new PdfDocument(new PdfReader(pdfPath)))
    {
        var pageNumbers = pdfDocument.GetNumberOfPages();
        for (int i = 1; i <= pageNumbers; i++)
        {
            LocationTextExtractionStrategy strategy = new LocationTextExtractionStrategy();
            PdfCanvasProcessor parser = new PdfCanvasProcessor(strategy);
            parser.ProcessPageContent(pdfDocument.GetFirstPage());
            pageText.Append(strategy.GetResultantText());
        }
    }
    return pageText.ToString();
}

void Recursive(string path)
{
    var files = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), path));
    filePaths.AddRange(files);

    var folders = Directory.GetDirectories(path);

    for (int i = 0; i < folders.Length; i++)
    {
        Recursive(folders[i]);
    }
}

Recursive("pdfs");

filePaths.ForEach((filePath) =>
{
    System.Console.WriteLine(filePath);
    var pageText = ReadFile(filePath);
    System.Console.WriteLine(pageText);
    System.Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------");
});