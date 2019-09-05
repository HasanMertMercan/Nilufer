using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SupplierService;

[assembly: HostingStartup(typeof(Startup))]
namespace SupplierService
{
    public class Startup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<ISupplierBusiness, SupplierBusiness>();
                services.AddSingleton<ISupplierRepository, SupplierRepository>();
            });
        }
    }
}
