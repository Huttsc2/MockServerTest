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

        private string GetJson(string fileName)
        {
            using StreamReader r = new StreamReader($"{PathToTestData}{fileName}");
            return r.ReadToEnd();
        }

        public List<User> GetUsers()
        {
            return JsonConvert.DeserializeObject<List<User>>(GetJson("Users.json"));
        }

        public User GetUserById1()
        {
            return JsonConvert.DeserializeObject<User>(GetJson("UserById1.json"));
        }

        public BookInfo GetNewBook()
        {
            return JsonConvert.DeserializeObject<BookInfo>(GetJson("NewBook.json"));
        }

        public BookInfo GetBookInfoById2()
        {
            return JsonConvert.DeserializeObject<BookInfo>(GetJson("BookInfoById2WithReview.json.json"));
        }

        public Review GetNewReview()
        {
            return JsonConvert.DeserializeObject<Review>(GetJson("NewReview.json"));
        }
    }
}
