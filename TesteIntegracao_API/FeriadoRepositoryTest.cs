using API_FeriadoAnbima;
using API_FeriadoAnbima.DBContext;
using API_FeriadoAnbima.Model;
using API_FeriadoAnbima.Repository;
using AutoMapper;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteIntegracao_API.Config;
using Xunit;

namespace TesteIntegracao_API
{
    public class FeriadoRepositoryTest
    {
       
        [Fact(DisplayName = "Busca de feriados ano sucesso")]
        [Trait("Categoria", "Busca no Banco de dados de ano, sucesso")]
        public void BuscaAno_BuscaDeAnoExistenteSucesso()
        {
            AutoMocker mocker = new AutoMocker();
            IEnumerable<Feriado> feriado = new List<Feriado>();
            mocker.GetMock<IFeriadoRepository>().Setup(r => r.BuscaDeFeriadosPorAno("2020")).Returns(Task.FromResult(feriado));
        }

        [Fact(DisplayName = "Busca de feriados ano falha")]
        [Trait("Categoria", "Busca no Banco de dados de ano, falha")]
        public void BuscaAno_BuscaDeAnoExistenteFalha()
        {
            AutoMocker mocker = new AutoMocker();
            IEnumerable<Feriado> feriado = Enumerable.Empty<Feriado>();
            mocker.GetMock<IFeriadoRepository>().Setup(r => r.BuscaDeFeriadosPorAno("2000")).Equals(null);
        }
    }
}
