using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Newtonsoft.Json;
using ApiTesting.Objects;
using ApiTesting.MockExpectations;
using ApiTesting.Helper;
using FluentAssertions;

namespace ApiTesting.Tests
{
    [TestClass]
    public class ApiTests
    {
        private RestClient _client { get; set; }

        [TestInitialize] public void Init() 
        {
            _client = new RestClient("http://localhost:1080");
            var resetRequest = new RestRequest("mockserver/reset", Method.Put);
            _client.Execute(resetRequest);
        }

        [TestMethod]
        public void GetUsers()
        {
            new ExpectationsCreater(_client).CreateGetUsersExpectation();

            RestRequest request = new RestRequest("users", Method.Get);
            RestResponse response = _client.Execute(request);
            List<User> actualResult = JsonConvert.DeserializeObject<List<User>>(response.Content);
            List<User> expectedResult = new TestDataReader().GetUsers();

            Assert.AreEqual(expectedResult.Count(), actualResult.Count());
        }

        [TestMethod]
        public void GetUserById1()
        {
            new ExpectationsCreater(_client).CreateGetUserById1Expectation();

            RestRequest request = new RestRequest("users/1", Method.Get);
            RestResponse response = _client.Execute(request);
            User actualUser = JsonConvert.DeserializeObject<User>(response.Content);
            User expectedUser = new TestDataReader().GetUserById1();

            actualUser.Should().BeEquivalentTo(expectedUser);
        }

        [TestMethod]
        public void GetBookInfoById1()
        {
            new ExpectationsCreater(_client).CreateGetBookInfoById1Expectation();

            RestRequest request = new RestRequest("books/1", Method.Get);
            RestResponse response = _client.Execute(request);
            BookInfo actualBookInfo = JsonConvert.DeserializeObject<BookInfo>(response.Content);
            BookInfo expectedBookInfo = new TestDataReader().GetBookInfoId1();
            
            actualBookInfo.Should().BeEquivalentTo(expectedBookInfo);
        }

        [TestMethod]
        public void PostNewBook()
        {
            new ExpectationsCreater(_client).CreatePostNewBookInfoExpectation();
            new ExpectationsCreater(_client).CreateGetListBookInfoExpectation();

            BookInfo newBook = new TestDataReader().GetNewBook();
            RestRequest addNewBookInfoRequest = new RestRequest("books", Method.Post);
            addNewBookInfoRequest.AddBody(newBook);
            _client.Execute(addNewBookInfoRequest);
            RestRequest getListBookInfo = new RestRequest("books", Method.Get);
            RestResponse response = _client.Execute(getListBookInfo);
            List<BookInfo> bookInfoList = JsonConvert.DeserializeObject<List<BookInfo>>(response.Content);

            bookInfoList.Should().ContainEquivalentOf(newBook);
        }

        [TestMethod]
        public void PutReviewIntoBookInfo()
        {

        }

    }
}