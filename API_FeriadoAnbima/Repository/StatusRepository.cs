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

        public void CreateStatus(Status status)
        {
            if (!status.EhValido().IsValid)
                return;
            _db.status.Add(status);
            _db.SaveChangesAsync();
        }
        public void UpdateStatus(Status status)
        {
            if (!status.EhValido().IsValid)
                return;
            _db.status.Update(status);
            _db.SaveChangesAsync();
        }
        public async Task<IList<Status>> FindAllStatus()
        {
            return await _db.status.ToListAsync();
        }
    }
}
