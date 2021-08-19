using API_FeriadoAnbima.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FeriadoAnbima.Repository
{
    public interface ILogDeRaspagemRequisicaoRepository
    {
        Task<LogDeRaspagemRequisicao> CreateLogRaspagemRequisicao(LogDeRaspagemRequisicao logRaspagemRequisicao);
        Task<LogDeRaspagemRequisicao> UpdateLogRaspagemRequisicao(LogDeRaspagemRequisicao logRaspagemRequisicao);
        Task<IList<LogDeRaspagemRequisicao>> FindAllLogRaspagemRequisicao();
        Task<LogDeRaspagemRequisicao> FindByIdLogRaspagemRequisicao(int id);
        
    }
}
