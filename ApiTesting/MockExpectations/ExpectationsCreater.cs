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
            _request.AddParameter("application/json", new TestRequestReader().PostNewBookIngoRequest(), ParameterType.RequestBody);
            _client.Execute(_request);
        }

        public void CreateGetListBookInfoExpectation()
        {
            _request.AddParameter("application/json", new TestRequestReader().GetListBookInfoRequest(), ParameterType.RequestBody);
            _client.Execute(_request);
        }
    }
}
