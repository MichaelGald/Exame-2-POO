using Examen_2_de_POO.API.Helpers;
using Examen_2_de_POO.Databases;
using Examen_2_de_POO.Services;
using Examen_2_de_POO.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Examen_2_de_POO
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
      
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(opts =>
            {
                opts.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //Add Custom services
            services.AddDbContext<ContextClientes>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IClienteServices, ClienteServices>();

            // Configurar AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
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