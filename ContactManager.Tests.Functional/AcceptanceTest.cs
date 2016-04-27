using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactManager.Tests.Functional
{
    [TestClass]
    public class AcceptanceTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public async Task ContactsRespondsOK()
        {
            string appHost = TestContext.Properties["appHost"] as string;
            if (string.IsNullOrWhiteSpace(appHost))
                Assert.Inconclusive();
            string path = "/contacts";
            var uri = new Uri(new Uri(appHost), path);
            var httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(uri);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
