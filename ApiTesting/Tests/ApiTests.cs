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

        [TestInitialize]
        public void Init() 
        {
            _client = new RestClient("http://localhost:1080");
            var resetRequest = new RestRequest("/mockserver/reset", Method.Put);
            _client.Execute(resetRequest);
        }

        [TestMethod]
        public void GetUsers()
        {
            new ExpectationsCreator(_client).CreateGetUsersExpectation();
            List<User> expectedUserList = new TestDataReader().GetUsers();

            RestRequest getRequest = new RestRequest("/users", Method.Get);
            RestResponse getResponse = _client.Execute(getRequest);
            List<User> actualUserList = JsonConvert.DeserializeObject<List<User>>(getResponse.Content);

            actualUserList.Should().BeEquivalentTo(expectedUserList);
        }

        [TestMethod]
        public void GetUserById1()
        {
            new ExpectationsCreator(_client).CreateGetUserById1Expectation();
            User expectedUser = new TestDataReader().GetUserById1();

            RestRequest getRrequest = new RestRequest("/users/1", Method.Get);
            RestResponse getResponse = _client.Execute(getRrequest);
            User actualUser = JsonConvert.DeserializeObject<User>(getResponse.Content);

            actualUser.Should().BeEquivalentTo(expectedUser);
        }

        [TestMethod]
        public void GetBookInfoById1()
        {
            new ExpectationsCreator(_client).CreateGetBookInfoById1Expectation();
            BookInfo expectedBookInfo = new TestDataReader().GetBookInfoId1();

            RestRequest getRequest = new RestRequest("/books/1", Method.Get);
            RestResponse getResponse = _client.Execute(getRequest);
            BookInfo actualBookInfo = JsonConvert.DeserializeObject<BookInfo>(getResponse.Content);
            
            actualBookInfo.Should().BeEquivalentTo(expectedBookInfo);
        }

        [TestMethod]
        public void PostNewBook()
        {
            new ExpectationsCreator(_client).CreatePostNewBookInfoExpectation();
            new ExpectationsCreator(_client).CreateGetListBookInfoExpectation();
            BookInfo bookInfoToPost = new TestDataReader().GetNewBook();

            RestRequest addNewBookInfoRequest = new RestRequest("/books", Method.Post);
            addNewBookInfoRequest.AddBody(bookInfoToPost);
            _client.Execute(addNewBookInfoRequest);
            RestRequest getListBookInfoRequest = new RestRequest("/books", Method.Get);
            RestResponse getListBookInfoResponse = _client.Execute(getListBookInfoRequest);
            List<BookInfo> actualBookInfoList = 
                JsonConvert.DeserializeObject<List<BookInfo>>(getListBookInfoResponse.Content);

            actualBookInfoList.Should().ContainEquivalentOf(bookInfoToPost);
        }

        [TestMethod]
        public void PutReviewIntoBookInfo()
        {
            new ExpectationsCreator(_client).CreatePutNewReviewIntoBookInfoById2Expectation();
            new ExpectationsCreator(_client).CreateGetBookInfoById2Expectation();
            Review reviewToPut = new TestDataReader().GetNewReview();

            RestRequest putReviewRequest = new RestRequest("/books/2/review", Method.Put);
            putReviewRequest.AddBody(reviewToPut);
            _client.Execute(putReviewRequest);
            RestRequest getBookInfoRequest = new RestRequest("/books/2", Method.Get);
            RestResponse getBookInfoResponse = _client.Execute(getBookInfoRequest);
            BookInfo actualBookInfo = JsonConvert.DeserializeObject<BookInfo>(getBookInfoResponse.Content);

            actualBookInfo.Reviews.Should().ContainEquivalentOf(reviewToPut);
        }

        [TestMethod]
        public void DeleteReviewIntoBookInfo()
        {
            new ExpectationsCreator(_client).CreateDeleteBookInfoById1Expectation();
            new ExpectationsCreator(_client).CreateGetListBookInfoAfterDelete();
            List<BookInfo> expectedBookInfoList = new TestDataReader().GetListBookInfoAfterDelete();

            RestRequest deleteBookInfoRequest = new RestRequest("/books/1", Method.Delete);
            _client.Execute(deleteBookInfoRequest);
            RestRequest getBookInfoRequest = new RestRequest("/books", Method.Get);
            RestResponse getBookInfoResponse = _client.Execute(getBookInfoRequest);
            List<BookInfo> actualBookInfoList = JsonConvert.DeserializeObject<List<BookInfo>>(getBookInfoResponse.Content);

            actualBookInfoList.Should().BeEquivalentTo(expectedBookInfoList);
        }
    }
}