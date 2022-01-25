using System.IO;

namespace ServicesLib
{
    public class FilesChecker
    {
        public static string GetIniContent(string path)
        {
            string a = string.Empty;
            if (File.Exists(path))
            {
                using (StreamReader sw = new(path))
                { a = sw.ReadToEnd(); }
            }
            else File.Create(path);
            return a;
        }
    }
}
