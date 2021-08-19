using API_FeriadoAnbima.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FeriadoAnbima.DBContext
{
    public class FeriadoAnbimaContext : DbContext
    {
        public DbSet<LogDeRaspagemRequisicao> logs { get; set; }
        public DbSet<Status> status { get; set; }
        public DbSet<Feriado> feriado { get; set; }
        public FeriadoAnbimaContext(DbContextOptions options) : base (options) { }
    }
}
