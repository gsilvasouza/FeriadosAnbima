using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using API_FeriadoAnbima.Model;

namespace TesteUnidade_API.FeriadoTests
{
    public class FeriadoTests
    {
        [Fact(DisplayName = "Feriado Válido")]
        [Trait("Categoria", "Feriado Tests")]
        //int id, string nome, string diaDaSemana, DateTime data, int ano
        public void Feriado_NovoFeriado_Valido()
        {
            //Arrange
            LogDeRaspagemRequisicao log = new LogDeRaspagemRequisicao(DateTime.UtcNow, true, 2020, "Requisição de busca dos feriado do ano: 2020 no site Anbima", "https://www.anbima.com.br/feriados/fer_nacionais/2020.asp");
            var feriado = new Feriado("Natal", "sexta-feira", DateTime.UtcNow, 2020, log);

            //Act
            var result = feriado.EhValido();

            //Assert 
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
            
        }

        [Fact(DisplayName = "Feriado, nome invalido")]
        [Trait("Categoria", "Feriado Tests")]
        //int id, string nome, string diaDaSemana, DateTime data, int ano
        public void Feriado_NovoFeriado_NomeInvalido()
        {
            LogDeRaspagemRequisicao log = new LogDeRaspagemRequisicao(DateTime.UtcNow, true, 2020, "Requisição de busca dos feriado do ano: 2020 no site Anbima", "https://www.anbima.com.br/feriados/fer_nacionais/2020.asp");
            var feriado = new Feriado( "" ,"sexta-feira", DateTime.UtcNow, 2020, log);

            //Act
            var result = feriado.EhValido();

            //Assert 
            Assert.False(result.IsValid);
            Assert.Equal("Por favor, certifique-se de ter inserido o nome do feriado", result.ToString());
        }

        [Fact(DisplayName = "Feriado, ano invalido")]
        [Trait("Categoria", "Feriado Tests")]
        //int id, string nome, string diaDaSemana, DateTime data, int ano
        public void Feriado_NovoFeriado_AnoInvalido()
        {
            LogDeRaspagemRequisicao log = new LogDeRaspagemRequisicao(DateTime.UtcNow, true, 2020, "Requisição de busca dos feriado do ano: 2020 no site Anbima", "https://www.anbima.com.br/feriados/fer_nacionais/2020.asp");
            var feriado = new Feriado("Natal", "sexta-feira", DateTime.UtcNow, 2000, log);

            //Act
            var result = feriado.EhValido();

            //Assert 
            Assert.False(result.IsValid);
            Assert.Equal("Por favor, digite um ano entre 2001 e 2078", result.ToString());
        }

        [Fact(DisplayName = "Feriado, dia da semana invalido")]
        [Trait("Categoria", "Feriado Tests")]
        //int id, string nome, string diaDaSemana, DateTime data, int ano
        public void Feriado_NovoFeriado_DiaDaSemanaInvalido()
        {
            LogDeRaspagemRequisicao log = new LogDeRaspagemRequisicao(DateTime.UtcNow, true, 2020, "Requisição de busca dos feriado do ano: 2020 no site Anbima", "https://www.anbima.com.br/feriados/fer_nacionais/2020.asp");
            var feriado = new Feriado("Natal", "", DateTime.UtcNow, 2020, log);

            //Act
            var result = feriado.EhValido();

            //Assert 
            Assert.False(result.IsValid);
            Assert.Equal("Por favor, certifique-se de ter inserido o dia da semana", result.ToString());
        }

        [Fact(DisplayName = "Feriado, dia da semana invalido")]
        [Trait("Categoria", "Feriado Tests")]
        //int id, string nome, string diaDaSemana, DateTime data, int ano
        public void Feriado_NovoFeriado_DataInvalido()
        {
            LogDeRaspagemRequisicao log = new LogDeRaspagemRequisicao(DateTime.UtcNow, true, 2020, "Requisição de busca dos feriado do ano: 2020 no site Anbima", "https://www.anbima.com.br/feriados/fer_nacionais/2020.asp");
            var feriado = new Feriado("Natal", "sexta-feira", DateTime.Now, 2020, log);

            //Act
            var result = feriado.EhValido();

            //Assert 
            Assert.False(result.IsValid);
            Assert.Equal("Por favor, certifique-se de ter inserido a data", result.ToString());
        }

        [Fact(DisplayName = "Feriado, requisicao invalida")]
        [Trait("Categoria", "Feriado Tests")]
        //int id, string nome, string diaDaSemana, DateTime data, int ano
        public void Feriado_NovoFeriado_RequisicaoInvalida()
        {
            var feriado = new Feriado("Natal", "sexta-feira", DateTime.UtcNow, 2020);

            //Act
            var result = feriado.EhValido();

            //Assert 
            Assert.False(result.IsValid);
            Assert.Equal("Por favor, certifique-se de ter inserido o id do log de requisição", result.ToString());
        }
    }
}
