using System.Text;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

namespace PdfUtilities;
public static class PdfUtilities
{
    public static string ReadFile(string pdfPath)
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
        var content = pageText.ToString();

        content = RemoveUnCharacters(content);
        return content;
    }

    private static string RemoveUnCharacters(string content)
    {
        List<char> unUsedCharacters = new List<char>()
        {
            '\n',
            '\t',
            '.',
            ',',
            ';',
            ':',
            ')',
            '(',
            '[',
            ']',
            '{',
            '}',
            '$',
            '!',
            '#',
            '%',
            '&',
            '*',
            '-',
            '_',
            '=',
            '+',
            '`',
            '/',
            '\\',
            '|',
            '~',
            '<',
            '>',
            '?',
            '0',
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
        };

        unUsedCharacters.ForEach((unUsedCharacter) =>
        {
            content = content.Replace(unUsedCharacter, ' ');
        });

        return content;
    }
}