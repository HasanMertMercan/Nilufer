using System;
using Database;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using Serilog.Configuration;
using Serilog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using CustomerService;

namespace Runtime
{
    class Program
    {
        private static bool isService;
        public static IConfiguration Configuration { get; }
         = new ConfigurationBuilder()
            .SetBasePath(BasePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        public static string BasePath
        {
            get
            {
                var assembly = typeof(Program).Assembly;
                var assemblyPath = Path.GetDirectoryName(assembly.Location);
                return Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).FullName;
                //return assemblyPath.Contains(@"\bin\") ? Directory.GetCurrentDirectory() : assemblyPath;
            }
        }

        public static string LogPath
        {
            get
            {
                return Path.Combine(BasePath, "Logs");
            }
        }
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StoreDbContext>(o => o.UseMySQL(Configuration.GetConnectionString("NiluferDB")));
            services.AddTransient<ICustomerBusiness, CustomerBusiness>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            //services.AddTransient<IProductBusiness, ProductBusiness>();
            //services.AddTransient<IProductRepository, ProductRepository>();

           
        }

        public static async Task Main(string[] args)
        {
            isService = !(Debugger.IsAttached || args.Contains("--console"));
            var outputTemplate = "{Timestamp:dd-MM-yyyy HH:mm:ss.fff zz} [{Level:u3}] ({SourceContext}) {Message:lj}{NewLine}{Exception}";
            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(Configuration)
            //    .Enrich.FromLogContext()
            //    .WriteTo.Console(outputTemplate: outputTemplate)
            //    .WriteTo.File($"{LogPath}/StoreHelper_.log", rollingInterval: RollingInterval.Day, outputTemplate: outputTemplate)
            //    .CreateLogger();

            try
            {
                Log.Information("Starting Store Service runtime.");
                Log.Debug(BasePath);

                

            } catch (Exception ex)
            {
                Log.Fatal(ex, "Store Service runtime terminated unexpectedly.");
            }
        }

        private static void MigrateDatabase(IWebHost webHost)
        {
            var serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<StoreDbContext>();

                dbContext.Database.Migrate();
            }
        }

        //public static IWebHost BuildHost(string[] args)
        //{
        //    return WebHost.CreateDefaultBuilder(args)
        //        .ConfigureAppConfiguration((hostContext, appConfig) =>
        //        {
        //            hostContext.HostingEnvironment.ApplicationName = "Store Service";
        //        });
        //}
    }
}
