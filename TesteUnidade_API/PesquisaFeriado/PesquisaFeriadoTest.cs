using API_FeriadoAnbima.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TesteUnidade_API.PesquisaFeriadoTest
{
    public class PesquisaFeriadoTest
    {

        [Fact(DisplayName = "LogDeRaspagemRequisicao, ano nulo")]
        [Trait("Categoria", "LogDeRaspagemRequisicao Tests")]
        public void LogDeRaspagemRequisicao_AnoValido()
        {
            //Arrange
            PesquisaFeriado log = new PesquisaFeriado(2002);

            //Act
            var result = log.EhValido();

            //Assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "LogDeRaspagemRequisicao, ano nulo")]
        [Trait("Categoria", "LogDeRaspagemRequisicao Tests")]
        public void LogDeRaspagemRequisicao_AnoInvalidoNull()
        {
            //Arrange
            PesquisaFeriado log = new PesquisaFeriado();

            //Act
            var result = log.EhValido();

            //Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "LogDeRaspagemRequisicao, ano nulo")]
        [Trait("Categoria", "LogDeRaspagemRequisicao Tests")]
        public void LogDeRaspagemRequisicao_AnoInvalido()
        {
            //Arrange
            PesquisaFeriado log = new PesquisaFeriado(2000);

            //Act
            var result = log.EhValido();

            //Assert
            Assert.False(result.IsValid);
            Assert.Equal("Por favor, certifique-se de digitar um ano entre 2001 e 2078", result.ToString());
        }
    }
}
