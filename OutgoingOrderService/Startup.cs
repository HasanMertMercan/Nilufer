using OutgoingOrderService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Startup))]
namespace OutgoingOrderService
{
    public class Startup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IOutgoingOrderBusiness, OutgoingOrderBusiness>();
                services.AddSingleton<IOutgoingOrderRepository, OutgoingOrderRepository>();
            });
        }
    }
}
