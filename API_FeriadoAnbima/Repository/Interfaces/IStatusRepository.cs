using API_FeriadoAnbima.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FeriadoAnbima.Repository
{
    public interface IStatusRepository
    {
        Task<Status> CreateStatus(Status status);
        Task<Status> UpdateStatus(Status status);
        Task<IList<Status>> FindAllStatus();
    }
}
