using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using ApiTesting.Helper;

namespace ApiTesting.Tests
{
    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public void Get()
        {
            RestClient client = new RestClient("http://localhost:1080");
            RestRequest reserRequest = new RestRequest("mockserver/reset", Method.Put);
            client.Execute(reserRequest);

            RestRequest putRequest = new RestRequest("mockserver/expectation", Method.Put);
            putRequest.AddHeader("Content-Type", "application/json");
            string putRequestBody = new TestRequestReader().GetTestRequest();
            putRequest.AddParameter("application/json", putRequestBody, ParameterType.RequestBody);
            client.Execute(putRequest);

            RestRequest getRequest = new RestRequest("some/test/path", Method.Get);
            RestResponse getResponse = client.Execute(getRequest);
            string getResponseBody = getResponse.Content;
            Assert.IsTrue(getResponseBody.Contains("someResponse"));
        }
    }
}