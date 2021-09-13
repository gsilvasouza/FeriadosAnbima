using API_FeriadoAnbima.AutoMapper;
using API_FeriadoAnbima.DBContext;
using API_FeriadoAnbima.Repository;
using API_FeriadoAnbima.Scrapping;
using API_FeriadoAnbima.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FeriadoAnbima
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FeriadoAnbimaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Registrando o automapper na startup
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper(); //registrando e criando o automapper
            services.AddSingleton(mapper);
            MappingList mappingList = new MappingList(mapper);
            services.AddSingleton(mappingList);
            services.AddScoped<ILogDeRaspagemRequisicaoRepository, LogDeRaspagemRequisicaoRepository>();
            services.AddScoped<IFeriadoRepository, FeriadoRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_FeriadoAnbima", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_FeriadoAnbima v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            //app.UseCors("Cors");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
