using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASpNetMvc_test2.Settings;
using Domain.Abstract;
using Domain.Concrete;
using Domain.DbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebCis
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("Settings/MainSetting.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Настройка параметров и DI
            services.AddOptions();

            // создание объекта MainSetting по ключам из конфигурации
            services.Configure<MainSetting>(Configuration);

            // EF
            var connection = @"Server=(localdb)\mssqllocaldb;Database=CisDb_test;Trusted_Connection=True;";
            services.AddDbContext<CisDbContext>(options => options.UseSqlServer(connection));

            // Add framework services.
            services.AddMvc();

            services.AddScoped<IUnitOfWork, UnitOfWork>();  //на каждый запрос свой объект
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });



            Initialize();
        }


        private void Initialize()
        {
            // InitializeDb.Initialize(app.ApplicationServices);

            //QuartzApkDkReglamentRegSh.Start();
        }
    }
}
