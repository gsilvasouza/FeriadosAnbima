using API_FeriadoAnbima;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteIntegracao_API.Config;
using Xunit;

namespace TesteIntegracao_API
{
    [TestCaseOrderer("AnbimaApi.Tests", "AnbimaApi.Tests")]
    [Collection(nameof(IntegrationApiTestsFixtureCollection))]
    public class AnbimaApiTests
    {
        private readonly IntegrationTestsFixture<StartupApiTests> _testsFixture;

        public AnbimaApiTests(IntegrationTestsFixture<StartupApiTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Busca de feriados ano")]
        [Trait("Categoria", "Integração API - Ano")]
        public async Task BuscaAno_RetornoSucesso()
        {
            string ano = "2021";

            var getResponse = await _testsFixture.Client.GetAsync($"/api/FeriadosAnbima/{ano}");

            getResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Busca de feriados ano")]
        [Trait("Categoria", "Integração API - Ano, Falha ano invalido")]
        public async Task BuscaAno_RetornoInvalido()
        {
            string ano = "1999";

            var getResponse = await _testsFixture.Client.GetAsync($"/api/FeriadosAnbima/{ano}");

            getResponse.StatusCode.Equals(400);
        }
    }
}
