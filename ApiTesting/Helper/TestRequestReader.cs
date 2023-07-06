namespace ApiTesting.Helper
{
    public class TestRequestReader
    {
        public string GetTestRequest()
        {
            string path = PathFinder.GetRootDirectory();
            using StreamReader r = new(path + "/TestData/Put.json");
            return r.ReadToEnd();
        }
    }
}
