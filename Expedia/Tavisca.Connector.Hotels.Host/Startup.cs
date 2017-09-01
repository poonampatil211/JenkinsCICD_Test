using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Globalization;
using StructureMap;
using System.IO;

namespace Travel.Connectors.Hotel
{
    public class Startup
    {
        IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                //.SetBasePath(Directory.GetCurrentDirectory())
                //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            // Add framework services.
            services.AddMvc()
                .AddControllersAsServices();

            var serviceProvider = ConfigureIoC(services);
            //ExceptionPolicy.Configure(serviceProvider.GetRequiredService<IErrorHandler>());
            return serviceProvider;
        }

        public IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = new Container();
            container.Configure(config =>
                        {
                            //Populate the container using the service collection
                            config.Populate(services);
                        });
            return container.GetInstance<IServiceProvider>();
        }


        // RoomRates Dev checkin 1
        // BookDev commit 1
        // BookDev commit 2
        // BookDev commit 3

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMvc();
        }
    }
}
