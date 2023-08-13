namespace ApiTesting.Helper
{
    public class TestRequestReader
    {
        private string PathToMocks = $"{PathFinder.GetRootDirectory()}/MockResponses/";

        public string GetUsersRequest()
        {
            using StreamReader r = new($"{PathToMocks}GetUsers.json");
            return r.ReadToEnd();
        }

        public string GetUserById1Request()
        {
            using StreamReader r = new($"{PathToMocks}GetUserById1.json");
            return r.ReadToEnd();
        }

        public string GetBookInfoById1Request()
        {
            using StreamReader r = new($"{PathToMocks}GetBookInfoById1.json");
            return r.ReadToEnd();
        }

        public string PostNewBookIngoRequest()
        {
            using StreamReader r = new($"{PathToMocks}SuccessfulPostNewBookInfo.json");
            return r.ReadToEnd();
        }

        public string GetListBookInfoRequest()
        {
            using StreamReader r = new($"{PathToMocks}GetListBookInfo.json");
            return r.ReadToEnd();
        }
    }
}
