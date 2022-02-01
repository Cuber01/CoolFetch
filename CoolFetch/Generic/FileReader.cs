namespace CoolFetch.Generic
{
    public static class FileReader
    {
        
        public static string getFileString(string path)
        {
            return System.IO.File.ReadAllText(path);
        }
        
        public static string[] getFileLines(string path)
        {
            return System.IO.File.ReadAllLines(path);
        }
        
        
    }
}