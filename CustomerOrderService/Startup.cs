using CustomerOrderService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Startup))]
namespace CustomerOrderService
{
    public class Startup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<ICustomerOrderBusiness, CustomerOrderBusiness>();
                services.AddSingleton<ICustomerOrderRepository, CustomerOrderRepository>();
            });
        }
    }
}
