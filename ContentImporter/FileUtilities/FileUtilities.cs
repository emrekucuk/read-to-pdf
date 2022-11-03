namespace ContentImporter.FileUtilites;

public static class FileUtilities
{
    public static List<string> filePaths = new List<string>();
    public static List<string> GetAllFileFromDirectory(string path)
    {
        var files = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), path));
        filePaths.AddRange(files);

        var folders = Directory.GetDirectories(path);

        for (int i = 0; i < folders.Length; i++)
        {
            GetAllFileFromDirectory(folders[i]);
        }

        return filePaths;
    }
}