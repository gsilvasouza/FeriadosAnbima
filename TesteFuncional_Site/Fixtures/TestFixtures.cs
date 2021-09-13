using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFuncional_Site.Helper;

namespace TesteFuncional_Site.Fixtures
{
    public class TestFixtures : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public TestFixtures()
        {
            Driver = new ChromeDriver(TestHelper.CaminhoDoExecutavelChrome);
        }

        //TearDown -> Pratica para liberação do recurso(navegador)
        //A cada teste abre e fecha o navegador por causa da implementação da interface IDisposable
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
