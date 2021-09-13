using API_FeriadoAnbima;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TesteIntegracao_API.Config
{
    [CollectionDefinition(nameof(IntegrationApiTestsFixtureCollection))] //Collection fixture
    public class IntegrationApiTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<StartupApiTests>>{ }
    public class IntegrationTestsFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly ApiAnbimaFactory<TStartup> Factory;
        public HttpClient Client;

        public IntegrationTestsFixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = true,
                BaseAddress = new Uri("https://localhost:5001/"),
                HandleCookies = true,
                MaxAutomaticRedirections = 7
            };
            Factory = new ApiAnbimaFactory<TStartup>();
            Client = Factory.CreateClient(clientOptions);
        }

        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}
