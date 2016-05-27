using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApi._00_CommonUtility.I_Contracts;
using WebApi._00_CommonUtility.I_Contracts.IRepo;
using WebApi._00_CommonUtility.I_Contracts.ISevices;
using WebApi._01_DataAccess;
using WebApi._01_DataAccess.Repo;
using WebApi._02_BusinessLogic.ServicesManager;

namespace WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("config.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.

            services.AddSingleton<IUoW, UoW>();
            services.AddSingleton<IUserRepo, UserRepo>();
            services.AddSingleton<IUserServices, UserServices>();

            var sqlConnectionString = Configuration["DataAccessMsSqlServerProvider:ConnectionString"];
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(sqlConnectionString));


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
