using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_FeriadoAnbima.AutoMapper;
using API_FeriadoAnbima.DBContext;
using API_FeriadoAnbima.Repository;
using API_FeriadoAnbima.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API_FeriadoAnbima
{
    public class StartupApiTests
    {
        public StartupApiTests(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; set; }
        public void ConfigurationServices(IServiceCollection services)
        {
            services.AddDbContext<FeriadoAnbimaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Registrando o automapper na startup
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper(); //registrando e criando o automapper
            services.AddSingleton(mapper);

            FeriadoAnbimaService service = new FeriadoAnbimaService();
            services.AddSingleton(service);

            services.AddScoped<ILogDeRaspagemRequisicaoRepository, LogDeRaspagemRequisicaoRepository>();
            services.AddScoped<IFeriadoRepository, FeriadoRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
