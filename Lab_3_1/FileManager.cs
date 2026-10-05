using System.IO;
namespace FileIO.Lib;

public class FileManager
{
    public void WriteToFile(string filePath, string content)
    {
       using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        using (StreamWriter writer = new StreamWriter(fs))
        {
            writer.Write(content);
        }
    }
    public string ReadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
        return string.Empty;
        }
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        using (StreamReader reader = new StreamReader(fs))
        {
            return reader.ReadToEnd();
        }
    }
}