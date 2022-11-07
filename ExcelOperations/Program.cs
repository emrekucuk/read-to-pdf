using OfficeOpenXml;

void ReadExcelFile()
{
    try
    {
        var files = Path.Combine(Directory.GetCurrentDirectory(), "deneme.xlsx");
        var pdfModelList = new List<PdfModel>();

        using var package = new ExcelPackage(files);
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        var currentSheet = package.Workbook.Worksheets;

        for (int sheetIterator = 0; sheetIterator < currentSheet.Count; sheetIterator++)// Normal sartlarda rowIterator = 0 olacak
        {
            var workSheet = currentSheet[sheetIterator];
            var noOfCol = workSheet.Dimension.End.Column;
            var noOfRow = workSheet.Dimension.End.Row;
            var columnNames = new List<string>();

            for (int rowIterator = 1; rowIterator <= noOfRow; rowIterator++)
            {
                var pdfModel = new PdfModel();

                if (rowIterator != 1)
                    pdfModelList.Add(pdfModel);

                for (int columnIterator = 1; columnIterator <= noOfCol; columnIterator++)
                {
                    var value = workSheet.Cells[rowIterator, columnIterator].Value?.ToString();
                    if (rowIterator == 1)
                    {
                        columnNames.Add(value);
                        continue;
                    }

                    AssignValue(pdfModel, columnNames[columnIterator - 1], value);
                }
            }
        }
        System.Console.WriteLine("***************************************************************");
        pdfModelList.ForEach((pdfModel) =>
        {
            System.Console.WriteLine("KA :" + pdfModel.KaynakAdi);
            System.Console.WriteLine("YT :" + pdfModel.YayinTarihi);
            System.Console.WriteLine("T :" + pdfModel.Tur);
            System.Console.WriteLine("I :" + pdfModel.Isim);
            System.Console.WriteLine("Y :" + pdfModel.Yayinlayan);
            System.Console.WriteLine("S :" + pdfModel.Sayfa);
            System.Console.WriteLine("D :" + pdfModel.Dil);
            System.Console.WriteLine("C :" + pdfModel.Cilt);
            System.Console.WriteLine("S :" + pdfModel.Sayi);
            System.Console.WriteLine("I :" + pdfModel.ISSN);
            System.Console.WriteLine("I :" + pdfModel.ISBN);
            System.Console.WriteLine("P :" + pdfModel.PdfAdo);
            System.Console.WriteLine("\n\n***************************************");
        });

        // var conn = ConfigurationManager.ConnectionStrings["Development"].ConnectionString;
        // await using var connString = new SqlConnection(conn);
        // connString.Open();
        // await BulkWriter.InsertAsync(pdfModelList, "[Orders]", connString, CancellationToken.None);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }

}

void AssignValue(PdfModel pdfModel, string columnName, string value)
{
    switch (columnName)
    {
        case "KAYNAK ADI":
            pdfModel.KaynakAdi = value;
            break;
        case "YAYIN TARİHİ":
            pdfModel.YayinTarihi = value;
            break;
        case "TÜR":
            pdfModel.Tur = value;
            break;
        case "İSİM":
            pdfModel.Isim = value;
            break;
        case "YAYINLAYAN":
            pdfModel.Yayinlayan = value;
            break;
        case "SAYFA":
            pdfModel.Sayfa = value;
            break;
        case "DİL":
            pdfModel.Dil = value;
            break;
        case "CİLT":
            pdfModel.Cilt = value;
            break;
        case "SAYI":
            pdfModel.Sayi = value;
            break;
        case "ISSN":
            pdfModel.ISSN = value;
            break;
        case "ISBN":
            pdfModel.ISBN = value;
            break;
        case "PDF ADO":
            pdfModel.PdfAdo = value;
            break;


        default:
            break;
    }
}

ReadExcelFile();
