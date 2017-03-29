using Marqueone.TimeAndMaterials.Api.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Marqueone.TimeAndMaterials.Api.DataAccess.Services;

namespace TimeAndMaterials
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TamContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TamContext")));
                
            services.AddScoped<MaterialService>();
            services.AddScoped<ServicesService>();
            services.AddScoped<EquipmentService>();
            services.AddScoped<AddressService>();
            services.AddScoped<ContactService>();
            services.AddScoped<EmployeeService>();
            services.AddScoped<ServicesService>();
            services.AddScoped<TradeService>();
            services.AddScoped<ProjectService>();
            services.AddScoped<CompanyService>();
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
