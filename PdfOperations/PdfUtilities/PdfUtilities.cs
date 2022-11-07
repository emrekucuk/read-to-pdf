using System.Text;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

namespace PdfOperations.PdfUtilities;
public static class PdfUtilities
{
    public static string ReadFile(string pdfPath)
    {
        PdfReader pdfReader = new PdfReader(pdfPath);
        PdfDocument pdfDoc = new PdfDocument(pdfReader);
        string pageContent = null;
        for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
        {
            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
            pageContent += PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), strategy);
        }
        pdfDoc.Close();
        pdfReader.Close();
        var content = pageContent.ToString();

        content = RemoveUnCharacters(content);
        content = FixTurkishCharacters(content);
        return content;
    }

    private static string FixTurkishCharacters(string content)
    {
        content = content.Replace('Đ', 'İ');
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