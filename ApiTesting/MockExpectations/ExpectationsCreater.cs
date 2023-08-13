using ApiTesting.Helper;
using RestSharp;

namespace ApiTesting.MockExpectations
{
    public class ExpectationsCreater
    {
        private RestClient _client { get; set; }
        private RestRequest _request { get; set; }

        public ExpectationsCreater(RestClient client)
        {
            _client = client;
            _request = new RestRequest("mockserver/expectation", Method.Put);
            _request.AddHeader("Content-Type", "application/json");
        }

        public void CreateGetUsersExpectation()
        {
            _request.AddParameter("application/json", new TestRequestReader().GetUsersRequest(), ParameterType.RequestBody);
            _client.Execute(_request);
        }

        public void CreateGetUserById1Expectation()
        {
            _request.AddParameter("application/json", new TestRequestReader().GetUserById1Request(), ParameterType.RequestBody);
            _client.Execute(_request);
        }

        public void CreateGetBookInfoById1Expectation()
        {
            _request.AddParameter("application/json", new TestRequestReader().GetBookInfoById1Request(), ParameterType.RequestBody);
            _client.Execute(_request);
        }

        public void CreatePostNewBookInfoExpectation()
        {
            _request.AddParameter("application/json", new TestRequestReader().PostNewBookInfoRequest(), ParameterType.RequestBody);
            _client.Execute(_request);
        }

        public void CreateGetListBookInfoExpectation()
        {
            _request.AddParameter("application/json", new TestRequestReader().GetListBookInfoRequest(), ParameterType.RequestBody);
            _client.Execute(_request);
        }

        public void CreatePutNewReviewIntoBookInfoById2Expectation()
        {
            _request.AddParameter("application/json", new TestRequestReader().PutBookInfoById2Request(), ParameterType.RequestBody);
            _client.Execute(_request);
        }

        public void CreateGetBookInfoById2Expectation()
        {
            _request.AddParameter("application/json", new TestRequestReader().GetBookInfoById2Request(), ParameterType.RequestBody);
            _client.Execute(_request);
        }

        public void CreateDeleteBookInfoById1Expectation()
        {
            _request.AddParameter("application/json", new TestRequestReader().DeleteBookInfoById1Request(), ParameterType.RequestBody);
            _client.Execute(_request);
        }

        public void CreateGetListBookInfoAfterDelete()
        {
            _request.AddParameter("application/json", new TestRequestReader().GetListBookInfoAfterDelete(), ParameterType.RequestBody);
            _client.Execute(_request);
        }

    }
}
