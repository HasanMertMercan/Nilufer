using ExpenditureService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Startup))]
namespace ExpenditureService
{
    public class Startup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IExpenditureBusiness, ExpenditureBusiness>();
                services.AddSingleton<IExpenditureRepository, ExpenditureRepository>();
            });
        }
    }
}
