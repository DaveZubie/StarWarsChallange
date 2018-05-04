using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsChallenge;
using System.Net;

namespace UnitTestProject
{
    [TestClass]
    public class ApiIntegrationTest
    {
        [TestMethod]
        public void IntegrationWorksTest()
        { 
            var api = new ApiHandler();
            var url = string.Format("{0}{1}", Constants.starWarsApi, "/starships");

            api.APIReader(url);

            Assert.AreEqual(HttpStatusCode.OK, api.StatusCode);           
        }

        [TestMethod]
        public void IntegrationInvalidRequestTest()
        {
            var api = new ApiHandler();
            var url = string.Format("{0}{1}", Constants.starWarsApi, "/badtest");

            api.APIReader(url);

            Assert.AreEqual(HttpStatusCode.NotFound, api.StatusCode);
        }
    }
}
