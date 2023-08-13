using ApiTesting.Objects;
using Newtonsoft.Json;

namespace ApiTesting.Helper
{
    public class TestDataReader
    {
        private string PathToTestData = $"{PathFinder.GetRootDirectory()}/TestData/";

        public BookInfo GetBookInfoId1()
        {
            using StreamReader r = new StreamReader($"{PathToTestData}BookInfoById1.json");
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<BookInfo>(json);
        }

        public List<User> GetUsers()
        {
            using StreamReader r = new StreamReader($"{PathToTestData}Users.json");
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<List<User>>(json);
        }

        public User GetUserById1()
        {
            using StreamReader r = new StreamReader($"{PathToTestData}UserById1.json");
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<User>(json);
        }

        public BookInfo GetNewBook()
        {
            using StreamReader r = new StreamReader($"{PathToTestData}NewBook.json");
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<BookInfo>(json);
        }
    }
}
