using API_FeriadoAnbima.DBContext;
using API_FeriadoAnbima.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FeriadoAnbima.Repository
{
    public class StatusRepository : IStatusRepository
    {
        private readonly FeriadoAnbimaContext _db;

        public StatusRepository(FeriadoAnbimaContext db)
        {
            this._db = db;
        }

        public async Task<Status> CreateStatus(Status status)
        {
            if (!status.EhValido().IsValid)
                throw new Exception("Erro ao criar o objeto status no banco de dados");
            _db.status.Add(status);
            await _db.SaveChangesAsync();
            return status;
        }
        public async Task<Status> UpdateStatus(Status status)
        {
            if (!status.EhValido().IsValid)
                throw new Exception("Erro ao criar o objeto status no banco de dados");
            _db.status.Update(status);
            await _db.SaveChangesAsync();
            return status;
        }
        public async Task<IList<Status>> FindAllStatus()
        {
            return await _db.status.ToListAsync();
        }
    }
}
