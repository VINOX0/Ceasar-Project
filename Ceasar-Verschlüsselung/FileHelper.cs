using System;
using System.IO;

static class FileHelper
{
    public static string DateiLesenSicher(string path)
    {
        if (File.Exists(path))
            return File.ReadAllText(path);
        throw new FileNotFoundException("Datei nicht gefunden", path);
    }

    public static void DateiSchreibenSicher(string path, string content)
    {
        string dir = Path.GetDirectoryName(path);
        if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        File.WriteAllText(path, content);
    }
}
