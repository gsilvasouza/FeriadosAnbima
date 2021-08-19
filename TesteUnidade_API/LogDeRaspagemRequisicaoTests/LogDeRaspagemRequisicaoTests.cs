using API_FeriadoAnbima.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TesteUnidade_API.LogDeRaspagemRequisicaoTests
{
    public class LogDeRaspagemRequisicaoTests
    {
        [Fact(DisplayName = "LogDeRaspagemRequisicao Válido")]
        [Trait("Categoria", "LogDeRaspagemRequisicao Tests")]
        public void LogDeRaspagemRequisicao_Valido()
        {
            //Arrange
            LogDeRaspagemRequisicao log = new LogDeRaspagemRequisicao(DateTime.UtcNow, true, 2020, "Requisição de busca dos feriado do ano: 2020 no site Anbima", "https://www.anbima.com.br/feriados/fer_nacionais/2020.asp");
            
            //Act
            var result = log.EhValido();

            //Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact(DisplayName = "LogDeRaspagemRequisicao, data invalido")]
        [Trait("Categoria", "LogDeRaspagemRequisicao Tests")]
        public void LogDeRaspagemRequisicao_DataInvalido()
        {
            //Arrange
            LogDeRaspagemRequisicao log = new LogDeRaspagemRequisicao(DateTime.Now, true, 2020, "Requisição de busca dos feriado do ano: 2020 no site Anbima", "https://www.anbima.com.br/feriados/fer_nacionais/2020.asp");

            //Act
            var result = log.EhValido();

            //Assert
            Assert.False(result.IsValid);
            Assert.Equal("Por favor, certifique-se de digitar uma data valida", result.ToString());
        }

        [Fact(DisplayName = "LogDeRaspagemRequisicao, isSucess invalido")]
        [Trait("Categoria", "LogDeRaspagemRequisicao Tests")]
        public void LogDeRaspagemRequisicao_isSucessInvalido()
        {
            //Arrange
            LogDeRaspagemRequisicao log = new LogDeRaspagemRequisicao(DateTime.UtcNow, 2020, "Requisição de busca dos feriado do ano: 2020 no site Anbima", "https://www.anbima.com.br/feriados/fer_nacionais/2020.asp");

            //Act
            var result = log.EhValido();

            //Assert
            Assert.False(result.IsValid);
            Assert.Equal("Por favor, certifique-se de ter inserido qual foi o resultado da requisição", result.ToString());
        }

        [Fact(DisplayName = "LogDeRaspagemRequisicao, ano invalido")]
        [Trait("Categoria", "LogDeRaspagemRequisicao Tests")]
        public void LogDeRaspagemRequisicao_AnoInvalido()
        {
            //Arrange
            LogDeRaspagemRequisicao log = new LogDeRaspagemRequisicao(DateTime.UtcNow, true, 2000, "Requisição de busca dos feriado do ano: 2020 no site Anbima", "https://www.anbima.com.br/feriados/fer_nacionais/2020.asp");

            //Act
            var result = log.EhValido();

            //Assert
            Assert.False(result.IsValid);
            Assert.Equal("Por favor, certifique-se de ter inserido um ano entre 2001 e 2078", result.ToString());
        }

        [Fact(DisplayName = "LogDeRaspagemRequisicao, enderecoHTTPS invalido")]
        [Trait("Categoria", "LogDeRaspagemRequisicao Tests")]
        public void LogDeRaspagemRequisicao_enderecoHttpsInvalido()
        {
            //Arrange
            LogDeRaspagemRequisicao log = new LogDeRaspagemRequisicao(DateTime.UtcNow, true, 2020, "", "Requisição de busca dos feriado do ano: 2020 no site Anbima");

            //Act
            var result = log.EhValido();

            //Assert
            Assert.False(result.IsValid);
            Assert.Equal("Por favor, certifique-se de ter inserido o endereço HTTPS da requisição", result.ToString());
        }

        [Fact(DisplayName = "LogDeRaspagemRequisicao, descrição invalido")]
        [Trait("Categoria", "LogDeRaspagemRequisicao Tests")]
        public void LogDeRaspagemRequisicao_DescricaoInvalido()
        {
            //Arrange
            LogDeRaspagemRequisicao log = new LogDeRaspagemRequisicao(DateTime.UtcNow, true, 2020, "https://www.anbima.com.br/feriados/fer_nacionais/2020.asp" , "" );

            //Act
            var result = log.EhValido();

            //Assert
            Assert.False(result.IsValid);
            Assert.Equal("Por favor, certifique-se de ter inserido a descrição da requisição", result.ToString());
        }
    }
}
