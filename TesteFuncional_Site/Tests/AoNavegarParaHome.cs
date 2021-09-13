using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFuncional_Site.Fixtures;
using Xunit;

namespace TesteFuncional_Site.Tests
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome
    {
        private IWebDriver driver;

        //Setup
        public AoNavegarParaHome(TestFixtures fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoChromeabertoDeveMostrarLeiloesNoTitulo()
        {
            //Arrange -> Atributo da classe

            //act
            //Act -> Navegar ate a home
            driver.Navigate().GoToUrl("http://localhost:4200/anbima-search");

            //assert
            Assert.Contains("Feriado Anbima", driver.Title);
        }
    }
}
