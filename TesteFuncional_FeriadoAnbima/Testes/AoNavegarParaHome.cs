using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFuncional_FeriadoAnbima.Fixtures;
using TesteFuncional_FeriadoAnbima.Helpers;
using Xunit;

namespace TesteFuncional_FeriadoAnbima.Testes
{
    public class AoNavegarParaHome
    {

        [Fact]
        public void DadoChromeAbertoDeveMostrarFeriadoAnbimaNoTitulo()
        {
            //Arrange
            IWebDriver _driver = new ChromeDriver(@"C:\Users\Gabriel\Downloads\chromedriver_win32");

            //Act -> Navegar ate a home
            _driver.Navigate().GoToUrl("http://localhost:4200/anbima-search");

            //assert
            Assert.Contains("Feriado Anbima", _driver.Title);
        }
    }
}
