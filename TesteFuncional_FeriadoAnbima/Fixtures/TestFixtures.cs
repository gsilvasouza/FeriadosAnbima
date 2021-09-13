using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFuncional_FeriadoAnbima.Helpers;

namespace TesteFuncional_FeriadoAnbima.Fixtures
{
    public class TestFixtures : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public TestFixtures()
        {
            this.Driver = new ChromeDriver(TestHelpers.CaminhoDoExecutavelChrome);
        }

        public void Dispose()
        {
            this.Driver.Quit();
        }
    }
}
