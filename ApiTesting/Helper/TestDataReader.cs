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

        public List<User> GetUsers() => JsonConvert.DeserializeObject<List<User>>(GetJson("Users.json"));
        public User GetUserById1() => JsonConvert.DeserializeObject<User>(GetJson("UserById1.json"));
        public BookInfo GetNewBook() => JsonConvert.DeserializeObject<BookInfo>(GetJson("NewBook.json"));
        public Review GetNewReview() => JsonConvert.DeserializeObject<Review>(GetJson("NewReview.json"));
        public List<BookInfo> GetListBookInfoAfterDelete() => 
            JsonConvert.DeserializeObject<List<BookInfo>>(GetJson("ListBookInfoAfterDelete.json"));
    }
}
