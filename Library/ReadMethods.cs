namespace AOC22.Library
{
    public static class ReadMethods
    {
        public static List<string> ReadFileIntoList(string path)
        {
            return File.ReadAllLines(path).ToList();
        }
    }
}
