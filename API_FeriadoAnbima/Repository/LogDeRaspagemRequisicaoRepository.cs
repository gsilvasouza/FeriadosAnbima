using API_FeriadoAnbima.DBContext;
using API_FeriadoAnbima.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FeriadoAnbima.Repository
{
    public class LogDeRaspagemRequisicaoRepository : ILogDeRaspagemRequisicaoRepository
    {
        private readonly FeriadoAnbimaContext _db;

        public LogDeRaspagemRequisicaoRepository(FeriadoAnbimaContext db)
        {
            this._db = db;
        }

        public async Task<LogDeRaspagemRequisicao> CreateLogRaspagemRequisicao(LogDeRaspagemRequisicao logRaspagemRequisicao)
        {
            if (!logRaspagemRequisicao.EhValido().IsValid)
                throw new Exception("Erro ao criar o objeto logDeRaspagemRequisicao no banco de dados"); ;
            _db.logs.Add(logRaspagemRequisicao);
            await _db.SaveChangesAsync();
            return logRaspagemRequisicao;
        }
        public async Task<LogDeRaspagemRequisicao> UpdateLogRaspagemRequisicaoAsync(LogDeRaspagemRequisicao logRaspagemRequisicao)
        {
            if (!logRaspagemRequisicao.EhValido().IsValid)
                throw new Exception("Erro ao criar o objeto logDeRaspagemRequisicao no banco de dados"); ;
            _db.logs.Update(logRaspagemRequisicao);
            await _db.SaveChangesAsync();
            return logRaspagemRequisicao;
        }
        public async Task<IList<LogDeRaspagemRequisicao>> FindAllLogRaspagemRequisicao()
        {
            return await _db.logs.ToListAsync();
        }

        public async Task<LogDeRaspagemRequisicao> FindByIdLogRaspagemRequisicao(int id)
        {
           return await _db.logs.FindAsync(id);
        }
    }
}
