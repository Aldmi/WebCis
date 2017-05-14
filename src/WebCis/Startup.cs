using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.DtoAccessLayer;
using Domain.Abstract;
using Domain.Concrete;
using Domain.DbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebCis.Model;
using WebCis.Settings;
using WebCis.Mapping;


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
                .AddJsonFile("Settings/MainSetting.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
        }


        public IConfigurationRoot Configuration { get; }
        private MapperConfiguration MapperConfiguration { get; set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Настройка параметров и DI
            services.AddOptions();

            // создание объекта MainSetting по ключам из конфигурации
            services.Configure<MainSetting>(Configuration);

            // Add framework services.
            services.AddMvc();

            //Mapper
            services.AddSingleton<IMapper>(sp => MapperConfiguration.CreateMapper());

            // StationDtoAcessLayer
            var connection = @"Server=(localdb)\mssqllocaldb;Database=CisDb_test;Trusted_Connection=True;"; //TODO: брать из настроек
            services.AddScoped<IStationDtoAccessLayer>(provider => new StationsDtoAccessLayer(connection));//на каждый запрос свой объект
            services.AddScoped(provider => new RegulatoryScheduleDtoAccessLayer(connection));//на каждый запрос свой объект


            // EF DEBUG for SeedData only  !!!!!!!!!!!!!!!
            services.AddDbContext<CisDbContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
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


           await Initialize(serviceProvider);
        }


        private async Task Initialize(IServiceProvider serviceProvider)
        {
           var unitOfWork = serviceProvider.GetService<IUnitOfWork>();
           await SeedData.Initialize(unitOfWork);

            //QuartzApkDkReglamentRegSh.Start();

          // var mainSetting_age = Configuration["age"];
        }
    }

}
