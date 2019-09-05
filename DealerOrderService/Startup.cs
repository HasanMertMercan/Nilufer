using DealerOrderService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Startup))]
namespace DealerOrderService
{
    public class Startup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IDealerOrderBusiness, DealerOrderBusiness>();
                services.AddSingleton<IDealerOrderRepository, DealerOrderRepository>();
            });
        }
    }
}
