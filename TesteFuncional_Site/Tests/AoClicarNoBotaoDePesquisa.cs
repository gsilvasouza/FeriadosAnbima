using App.Metrics;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TesteFuncional_Site.Fixtures;
using Xunit;

namespace TesteFuncional_Site.Tests
{
    [Collection("Chrome Driver")]
    public class AoClicarNoBotaoDePesquisa
    {
        private IWebDriver driver;

        //Setup
        public AoClicarNoBotaoDePesquisa(TestFixtures fixture)
        {
            driver = fixture.Driver;
        }

        [Theory]
        [InlineData("2000")]
        [InlineData("1998")]
        [InlineData("2079")]
        public void DadoAnoInvalidoPopUpDeAnoInvalido(string ano)
        {
            //arrange - dado chrome aberto, digitar ano invalido aparecer pop up solicitando um ano valido
            driver.Navigate().GoToUrl("http://localhost:4200/anbima-search");

            //capturando o iput
            var inputAno = driver.FindElement(By.Id("ano"));
            //escrevendo o ano no input
            inputAno.SendKeys(ano);

            //botao de registro
            var botaoRegistro = driver.FindElement(By.Id("btnPesquisa"));
            //clicar no botao
            botaoRegistro.Click();

            // Obtém o texto do Alert.
            string textoDoAlert = driver.SwitchTo().Alert().Text;

            // Fecha a janela do alert.
            driver.SwitchTo().Alert().Dismiss();

            Assert.Equal("Digite um ano entre 2001 e 2078", textoDoAlert);
        }

        [Theory]
        [InlineData("2020")]
        [InlineData("2019")]
        public void DadoAnoValidoPopUpDeAnoSucesso(string ano)
        {
            //arrange - dado chrome aberto, digitar ano invalido aparecer pop up solicitando um ano valido
            driver.Navigate().GoToUrl("http://localhost:4200/anbima-search");

            //capturando o iput
            var inputAno = driver.FindElement(By.Id("ano"));
            //escrevendo o ano no input
            inputAno.SendKeys(ano);

            //botao de registro
            var botaoRegistro = driver.FindElement(By.Id("btnPesquisa"));
            //clicar no botao
            botaoRegistro.Click();
            Thread.Sleep(3000);
            botaoRegistro.Click();
            // Obtém o texto do Alert.
            string textoDoAlert = driver.SwitchTo().Alert().Text;

            // Fecha a janela do alert.
            driver.SwitchTo().Alert().Dismiss();

            Assert.Equal("Sucesso", textoDoAlert);
        }

        [Theory]
        [InlineData("2020")]
        [InlineData("2019")]
        public void DadoAnoValidoApiForaDoArPopUpDeInsucesso(string ano)
        {
            //arrange - dado chrome aberto, digitar ano invalido aparecer pop up solicitando um ano valido
            driver.Navigate().GoToUrl("http://localhost:4200/anbima-search");

            //capturando o iput
            var inputAno = driver.FindElement(By.Id("ano"));
            //escrevendo o ano no input
            inputAno.SendKeys(ano);

            //botao de registro
            var botaoRegistro = driver.FindElement(By.Id("btnPesquisa"));
            //clicar no botao
            botaoRegistro.Click();
            Thread.Sleep(1000);
            botaoRegistro.Click();
            Thread.Sleep(5000);
            // Obtém o texto do Alert.
            string textoDoAlert = driver.SwitchTo().Alert().Text;

            // Fecha a janela do alert.
            driver.SwitchTo().Alert().Dismiss();

            Assert.Equal("Erro ao se comunicar com a api, tente novamente mais tarde", textoDoAlert);
        }
    }
}
