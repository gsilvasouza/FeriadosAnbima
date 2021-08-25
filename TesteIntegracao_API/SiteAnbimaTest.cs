using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TesteIntegracao_API
{
    public class SiteAnbimaTest
    {
        [Fact(DisplayName = "Busca de feriados ano")]
        [Trait("Categoria", "Integração Site Anbima")]
        public async Task BuscaAno_ConnectionSiteAnbima()
        {
            var ano = "2021";

            var html = @$"https://www.anbima.com.br/feriados/fer_nacionais/{ano}.asp";
            HtmlWeb web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.GetEncoding("UTF-8"),
            };

            HtmlDocument htmlDoc = web.Load(html);
            var table = htmlDoc.DocumentNode.SelectNodes("//table")[2];
            var dados = table.SelectNodes("//tr/td[@class='tabela'][@style='padding-left:10px;']");
            
            Assert.NotNull(dados);
        }
    }
}
