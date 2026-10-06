using System.IO;
using System.Text;

namespace FileIO.Lib
{
    public static class FileManager
    {
        // Читання всього тексту з файлу через файловий потік
        public static string ReadAll(string path)
        {
            if (!File.Exists(path))
            {
                return string.Empty;
            }

            using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            using StreamReader reader = new StreamReader(fs, Encoding.UTF8);
            return reader.ReadToEnd();
        }

        // Запис тексту у файл через файловий потік
        public static void WriteAll(string path, string content)
        {
            using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            using StreamWriter writer = new StreamWriter(fs, Encoding.UTF8);
            writer.Write(content);
        }
    }
}