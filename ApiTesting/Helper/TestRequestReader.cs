namespace ApiTesting.Helper
{
    public class TestRequestReader
    {
        private string PathToMocks = $"{PathFinder.GetRootDirectory()}/MockResponses/";

        private string ReadFileContent(string fileName)
        {
            using StreamReader r = new($"{PathToMocks}{fileName}");
            return r.ReadToEnd();
        }

        public string GetUsersRequest() => ReadFileContent("GetUsers.json");
        public string GetUserById1Request() => ReadFileContent("GetUserById1.json");
        public string GetBookInfoById1Request() => ReadFileContent("GetBookInfoById1.json");
        public string PostNewBookInfoRequest() => ReadFileContent("SuccessfulPostNewBookInfo.json");
        public string GetListBookInfoRequest() => ReadFileContent("GetListBookInfo.json");
        public string PutBookInfoById2Request() => ReadFileContent("SuccessfulPutNewReviewById2.json");
        public string GetBookInfoById2Request() => ReadFileContent("GetBookInfoById2.json");
        public string DeleteBookInfoById1Request() => ReadFileContent("SuccessfulDeleteBookInfoById1.json");
        public string GetListBookInfoAfterDelete() => ReadFileContent("GetListBookInfoAfterDelete.json");

    }
}
