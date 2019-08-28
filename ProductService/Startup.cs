using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ProductService;

[assembly: HostingStartup(typeof(Startup))]
namespace ProductService
{
    public class Startup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IProductBusiness, ProductBusiness>();
                services.AddSingleton<IProductRepository, ProductRepository>();
            });
        }
    }
}
