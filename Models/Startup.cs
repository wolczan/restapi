using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using WarehouseMVC.Infrastructure.Repositories;


/* public void ConfigureServices(IServiceCollection services)
       {
           services.AddControllers();

           // Register the Swagger generator, defining one or more Swagger documents
           services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new OpenApiInfo { PageTitle = "Moviemanagement", Version = "v1"});
               var filepath = Path.Combine(System.AppContext.BaseDirectory, "MovieManagement.Api.xml");
               { 
                   Title = "Movie Management API", 
                   Version = "v1",
                   Description = "A simple movie management API"
               });
       };
       // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
       public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
       {
           if (env.IsDevelopment())
           {
               app.UseDeveloperExceptionPage();
           }

           app.UseHttpsRedirection();

           app.UseRouting();

           app.UseAuthorization();

           // Enable middleware to serve generated Swagger as a JSON endpoint.
           app.UseSwagger();

           // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
           // specifying the Swagger JSON endpoint.
           app.UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie Management API V1");
           });

           app.UseEndpoints(endpoints =>
           {
               endpoints.MapControllers();
           });
       }
   }
}   */

namespace YourNamespace  // Replace with your actual namespace
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
{
    // From the first method
    services.AddDbContext<Context>(options =>
        options.UseSqlServer(ConfigurationBinder.GetConnectionString("DefaultConnection")));
    services.AddDefaultIdentity<IdentityUser>(Options => Options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<Context>();
    services.AddTransient<ICustomerRepository, CustomerRepository>();    
    services.AddScoped<ICustomerRepository, CustomerRepository>();
    services.AddTransient<IItemRepository, ItemRepository>(); 
    services.AddControllersWithViews();
    services.AddRazorPages();

    // From the second method
    services.AddControllers();

    // Register the Swagger generator, defining one or more Swagger documents
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo 
        {
            Title = "Movie Management API",
            Version = "v1",
            Description = "A simple movie management API"
        });

        var filepath = Path.Combine(System.AppContext.BaseDirectory, "MovieManagement.Api.xml");
        // TODO: Use the filepath if you want to integrate XML comments with Swagger
    });
}


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie Management API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

/* public void ConfigureServices(IServiceCollection services)
        {
           services.AddDbContext<Context>(options =>
            options.UseSqlServer(
                ConfigurationBinder.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(Options => Options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<Context>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();    
            services.AddControllersWithViews();
            services.AddRazorPages();
            )   */