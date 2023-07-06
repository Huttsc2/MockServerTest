using System.Text.RegularExpressions;

namespace ApiTesting.Helper
{
    public class PathFinder
    {
        public static string GetRootDirectory()
        {
            string dir = Directory.GetCurrentDirectory();
            Regex reg = new(".{0,}ApiTesting");
            return reg.Match(dir).Captures.First().Value;
        }
    }
}
