using API_FeriadoAnbima.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TesteIntegracao_API
{
    public class BancoDeDados
    {
        [Fact(DisplayName = "Busca de feriados ano")]
        [Trait("Categoria", "Integração Banco de dados")]
        public void BuscaAno_ConnectionBancoDeDados()
        {
            SqlConnection conn = new SqlConnection("Server=localhost;Database=AnbimaFeriado;Trusted_Connection=True;MultipleActiveResultSets=true");
            conn.Open();
            conn.Close();
            Assert.NotNull(conn);
        }
    }
}
