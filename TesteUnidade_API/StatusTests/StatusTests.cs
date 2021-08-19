using API_FeriadoAnbima.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TesteUnidade_API.StatusTests
{
    public class StatusTests
    {
        [Fact(DisplayName = "Status Válido")]
        [Trait("Categoria", "Status Tests")]
        public void Feriado_Status_Valido()
        {
            LogDeRaspagemRequisicao log = new LogDeRaspagemRequisicao(DateTime.UtcNow, true, 2020, "Requisição de busca dos feriado do ano: 2020 no site Anbima", "https://www.anbima.com.br/feriados/fer_nacionais/2020.asp");
            var status = new Status("Criação da lista FeriadoDto, dos valores resgatado", "Scrapping", log); //Criação do objeto status)

            //Act
            var result = status.EhValido();

            //Assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Status, descrição invalida")]
        [Trait("Categoria", "Status Tests")]
        public void Feriado_Status_DescricaoInvalida()
        {
            LogDeRaspagemRequisicao log = new LogDeRaspagemRequisicao(DateTime.UtcNow, true, 2020, "Requisição de busca dos feriado do ano: 2020 no site Anbima", "https://www.anbima.com.br/feriados/fer_nacionais/2020.asp");
            var status = new Status("", "Scrapping", log); //Criação do objeto status)

            //Act
            var result = status.EhValido();

            //Assert
            Assert.False(result.IsValid);
            Assert.Equal("Por favor, certifique-se de ter inserido a descrição do status", result.ToString());
        }

        [Fact(DisplayName = "Status, log invalido")]
        [Trait("Categoria", "Status Tests")]
        public void Feriado_Status_LogInvalido()
        {
            LogDeRaspagemRequisicao log = new LogDeRaspagemRequisicao(DateTime.UtcNow, true, 2020, "Requisição de busca dos feriado do ano: 2020 no site Anbima", "https://www.anbima.com.br/feriados/fer_nacionais/2020.asp");
            var status = new Status("Criação da lista FeriadoDto, dos valores resgatado", "", log); //Criação do objeto status)

            //Act
            var result = status.EhValido();

            //Assert
            Assert.False(result.IsValid);
            Assert.Equal("Por favor, certifique-se de ter inserido o tipo de log do status", result.ToString());
        }

        [Fact(DisplayName = "Status, requisição invalida")]
        [Trait("Categoria", "Status Tests")]
        public void Feriado_Status_RequisicaoInvalida()
        {
            LogDeRaspagemRequisicao log = new LogDeRaspagemRequisicao(DateTime.UtcNow, true, 2020, "Requisição de busca dos feriado do ano: 2020 no site Anbima", "https://www.anbima.com.br/feriados/fer_nacionais/2020.asp");
            var status = new Status("Criação da lista FeriadoDto, dos valores resgatado", "Scrapping"); //Criação do objeto status)

            //Act
            var result = status.EhValido();

            //Assert
            Assert.False(result.IsValid);
            Assert.Equal("Por favor, certifique-se de ter inserido o identificador do log de requisição", result.ToString());
        }
    }
}
