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
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data.SqlClient;
using Serugees.Apis.Models;
using Serilog;

namespace Serugees.Apis
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            /*if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
               // builder.AddUserSecrets<Startup>();
            }*/
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost";   // update me
                builder.UserID = "sa";              // update me
                builder.Password = "H%aD92nwqjj3";      // update me
                builder.InitialCatalog = "SerugeesDb";
            services.AddDbContext<SerugeesDbContext>(options => options.UseSqlServer(builder.ConnectionString));*/
            //services.AddDbContext<SerugeesDbContext>(opt => opt.UseInMemoryDatabase());
            var connectionString = Configuration.GetValue<string>("PostgresDb:ConnectionString") ?? Configuration.GetConnectionString("DefaultConnection_docker");
            services.AddDbContext<SerugeesDbContext>(options =>
                options.UseNpgsql(connectionString));
            services.AddMvc();
            services.AddScoped<ILoanRegistry, LoanRegistry>();
            services.AddSingleton<ILoanRegistry, LoanRegistry>();
            services.AddScoped<IMemberRegistry, MemberRegistry>();
            services.AddSingleton<IMemberRegistry, MemberRegistry>();
            // Add framework services.
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            string webRootPath = env.WebRootPath + "/serugees-api-{Date}.log";
            var log = new Serilog.LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.RollingFile(
                    pathFormat: (webRootPath),
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {SourceContext} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();

            loggerFactory.AddSerilog(log);
            app.UseMvc();
        }
    }
}
