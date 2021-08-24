using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SisAvikar.Core.Interfaces;
using SisAvikar.Core.Services;
using SisAvikar.Infrastructure.Data;
using SisAvikar.Infrastructure.Repositories;
using System;

namespace SisAvikar.Api
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
            
            services.AddMvc().AddFluentValidation(options => 
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            ); //Registramos los Validators

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //Realizar Mapeos
            services.AddControllers()
                
                //.ConfigureApiBehaviorOptions(options => {
                //options.SuppressModelStateInvalidFilter = true; //Ivalidar el ModelState
            //})
            ;

            services .AddDbContext<SisAvikarDemoContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString ("ConexionAvikar")) //Conexion a nuestra Base de datos
            );
            
            services.AddTransient<ISalonRepository, SalonRepository>(); //Injeccion de Dependencias
            services.AddTransient<IMesasRepository, MesaRepository>(); //Injeccion de Dependencias
            services.AddTransient<IMesaService, MesaService>(); //Injeccion de Dependencias
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
