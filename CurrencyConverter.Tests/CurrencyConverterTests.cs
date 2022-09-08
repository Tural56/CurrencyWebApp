using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebCurrencyConverterV2.Controllers;
using WebCurrencyConverterV2.Models;

namespace CurrencyConverter.Tests
{
    
    [TestFixture]
    public class CurrencyConverterTests
    {
        

        [Test]
        public async Task CheckStatus()
        {
            //Arrange

            WebApplicationFactory<Program> webHost = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });

            HttpClient httpClient = webHost.CreateClient();

            //Act
            HttpResponseMessage httpResponse = await httpClient.GetAsync("/");

            //Assert

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);

        }

        
    }
}
