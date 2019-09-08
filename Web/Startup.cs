using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerOrderService;
using CustomerService;
using DealerOrderService;
using DealerService;
using ExpenditureService;
using OutgoingOrderService;
using ProductService;
using SupplierService;
using Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Configuration;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Add DBContext - configure db connection settings
            services.AddDbContext<StoreDbContext>(o => o.UseMySQL(Configuration.GetConnectionString("NiluferDB")));

            services.AddTransient<ICustomerBusiness, CustomerBusiness>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerOrderBusiness, CustomerOrderBusiness>();
            services.AddTransient<ICustomerOrderRepository, CustomerOrderRepository>();
            services.AddTransient<IDealerOrderBusiness, DealerOrderBusiness>();
            services.AddTransient<IDealerOrderRepository, DealerOrderRepository>();
            services.AddTransient<IDealerBusiness, DealerBusiness>();
            services.AddTransient<IDealerRepository, DealerRepository>();
            services.AddTransient<IExpenditureBusiness, ExpenditureBusiness>();
            services.AddTransient<IExpenditureRepository, ExpenditureRepository>();
            services.AddTransient<IOutgoingOrderBusiness, OutgoingOrderBusiness>();
            services.AddTransient<IOutgoingOrderRepository, OutgoingOrderRepository>();
            services.AddTransient<IProductBusiness, ProductBusiness>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ISupplierBusiness, SupplierBusiness>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void MigrateDatabase(IWebHost webHost)
        {
            var serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<StoreDbContext>();

                dbContext.Database.Migrate();
            }
        }
    }
}
