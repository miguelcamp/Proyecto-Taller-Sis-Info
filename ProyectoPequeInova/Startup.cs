using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProyectoPequeInova.Data;
using ProyectoPequeInova.Data.Repository;
using ProyectoPequeInova.Services;

namespace ProyectoPequeInova
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddTransient<IAreaService, AreaService>();
            services.AddTransient<ICursoService, CursoService>();
            services.AddTransient<IPequeInovaRepository, PequeInovaRepository>();

            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<PequeInovaDBContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("PequeInovaDataBase")
                    )
            );

            services.AddAutoMapper(typeof(Startup));
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
