using Capacitacion.IRepositorios;
using Capacitacion.IServicios;
using Capacitacion.Servicios;
using Core.EF.Api;
using Core.EF.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositorios.Repositorios;
using AutoMapper;
namespace api_netcore
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
            services.AddCors();
            services.AddControllers();
            // CORS
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
            services.RegisterFormatter();
            services.ConfigureEntityFramework(Configuration.GetConnectionString("DefaultConnection"));
            services.AddAutoMapper(typeof(Core.EF.IUnitOfWork).Assembly, typeof(ReparticionRepositorio).Assembly,
             typeof(ReparticionService).Assembly);
            services.AddTransient<IReparticionRepositorio, ReparticionRepositorio>();
            services.AddTransient<IReparticionService, ReparticionService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder
                     .AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader());
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
