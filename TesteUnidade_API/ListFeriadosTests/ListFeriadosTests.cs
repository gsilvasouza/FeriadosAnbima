using API_FeriadoAnbima.Model;
using API_FeriadoAnbima.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TesteUnidade_API.ListFeriadosTests
{
    public class ListFeriadosTests
    {
        [Fact(DisplayName =  "ListFeriados valido")]
        [Trait("Categoria", "ListFeriados Tests")]
        public void ListFeriados_Valido()
        {
            List<FeriadoDto> feriados = new List<FeriadoDto>();
            FeriadoDto feriado1 = new FeriadoDto("Natal", "sexta-feira", DateTime.UtcNow, 2020);
            FeriadoDto feriado2 = new FeriadoDto("Natal", "sexta-feira", DateTime.UtcNow, 2020);
            feriados.Add(feriado1);
            feriados.Add(feriado2);
            var listFeriados = new ListFeriado(feriados, true);

            //Act
            var result = listFeriados.EhValido();

            //Assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "ListFeriados, feriados invalido")]
        [Trait("Categoria", "ListFeriados Tests")]
        public void ListFeriados_feriadosInvalido()
        {
            List<FeriadoDto> feriados = new List<FeriadoDto>();
            var listFeriados = new ListFeriado(feriados, true);

            //Act
            var result = listFeriados.EhValido();

            //Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "ListFeriados, isSucess invalido")]
        [Trait("Categoria", "ListFeriados Tests")]
        public void ListFeriados_IsSucessInvalido()
        {
            List<FeriadoDto> feriados = new List<FeriadoDto>();
            var listFeriados = new ListFeriado(feriados);

            //Act
            var result = listFeriados.EhValido();

            //Assert
            Assert.False(result.IsValid);
        }
    }
}
