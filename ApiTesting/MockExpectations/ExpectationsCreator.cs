using ApiTesting.Helper;
using RestSharp;

namespace ApiTesting.MockExpectations
{
    public class ExpectationsCreator
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;
        private readonly TestRequestReader _requestReader;

        public ExpectationsCreator(RestClient client)
        {
            _client = client;
            _request = new RestRequest("mockserver/expectation", Method.Put);
            _request.AddHeader("Content-Type", "application/json");
            _requestReader = new TestRequestReader();
        }

        private void CreateExpectation(string requestData)
        {
            _request.AddParameter("application/json", requestData, ParameterType.RequestBody);
            _client.Execute(_request);
        }

        public void CreateGetUsersExpectation() => CreateExpectation(_requestReader.GetUsersRequest());
        public void CreateGetUserById1Expectation() => CreateExpectation(_requestReader.GetUserById1Request());
        public void CreateGetBookInfoById1Expectation() => CreateExpectation(_requestReader.GetBookInfoById1Request());
        public void CreatePostNewBookInfoExpectation() => CreateExpectation(_requestReader.PostNewBookInfoRequest());
        public void CreateGetListBookInfoExpectation() => CreateExpectation(_requestReader.GetListBookInfoRequest());
        public void CreatePutNewReviewIntoBookInfoById2Expectation() => CreateExpectation(_requestReader.PutBookInfoById2Request());
        public void CreateGetBookInfoById2Expectation() => CreateExpectation(_requestReader.GetBookInfoById2Request());
        public void CreateDeleteBookInfoById1Expectation() => CreateExpectation(_requestReader.DeleteBookInfoById1Request());
        public void CreateGetListBookInfoAfterDelete() => CreateExpectation(_requestReader.GetListBookInfoAfterDelete());

    }
}
