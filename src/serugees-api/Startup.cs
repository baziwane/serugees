using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using serugees_api.Models;

namespace serugees_api
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
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost";   // update me
                builder.UserID = "sa";              // update me
                builder.Password = "H%aD92nwqjj3";      // update me
                builder.InitialCatalog = "Cars";
            services.AddDbContext<LoanContext>(options => options.UseSqlServer(builder.ConnectionString));
            //services.AddDbContext<LoanContext>(opt => opt.UseInMemoryDatabase());
            services.AddMvc();
            services.AddScoped<ILoanRepository, LoanRepository>();
            //services.AddSingleton<ITodoRepository, TodoRepository>();
            // Add framework services.
            
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
