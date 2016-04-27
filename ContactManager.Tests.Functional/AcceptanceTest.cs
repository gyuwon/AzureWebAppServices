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
        [TestMethod]
        public async Task ContactsRespondsOK()
        {
            string appHost = "https://contactmanager-app.azurewebsites.net";
            string path = "/contacts";
            var uri = new Uri(new Uri(appHost), path);
            var httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(uri);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
