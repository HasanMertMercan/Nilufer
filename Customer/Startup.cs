using CustomerService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Startup))]
namespace CustomerService
{
    public class Startup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<ICustomerBusiness, CustomerBusiness>();
                services.AddSingleton<ICustomerRepository, CustomerRepository>();
            });
        }
    }
}
