using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using WarehouseMVC.Infrastructure.Repositories;
using RestApi.Repositories;
using RestApi.Services;
using RestApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Routing;


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
    services.AddCors(options => 
    options.AddPolicy(name: "MyallowSpecificorigins",
    builder => 
    {
        builder.WithOrigins("https://localhost:44359") //.AllowAnyOrigin();
            .AllowAnyMethod()
            .AllowAnyHeader();
    }  
       ));
    // From the first method
    services.AddMvc();
    services.AddDbContext<Context>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    services.AddDefaultIdentity<IdentityUser>(Options => Options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<Context>();
    services.AddTransient<ICustomerRepository, CustomerRepository>();    
    services.AddScoped<ICustomerRepository, CustomerRepository>();
    //services.AddSingleton();  // problematic. consider exemption
    services.AddSingleton<MyService>();
    services.AddTransient<ItemRepository, ItemRepository>(); 
    services.AddControllersWithViews();
    services.AddRazorPages();
    services.AddControllers();
    services.AddHttpClient("API", client =>
    {
        client.BaseAddress = new Uri("https://localhost:44359");
    });



    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo 
        {
            Title = "Movie Management API",
            Version = "v1",
            Description = "A simple movie management API",
            TermsOfService = new Uri("https://example.com/ters"),
            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Name = "Maciej",
                Email = string.Empty,
                Url = new Uri("https://www.facebook.com/maciej.liberadzki.9"),
                            }
        });

        var filepath = Path.Combine(System.AppContext.BaseDirectory, "MovieManagement.Api.xml");
        c.IncludeXmlComments(filepath);
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
            app.UseCors();
            app.UseAuthorization();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie Management API V1");
                c.RoutePrefix = string.Empty; // It sets Swagger UI as a landing page
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}