using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaData.Models;
using PizzaShop.Repositories;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace PizzaShop
{
    public class Startup
    {

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            var logDB = Configuration.GetConnectionString("DataConnection");
            var logTable = "Logs";
            var opts = new ColumnOptions();
            Log.Logger = new LoggerConfiguration()
                .WriteTo.MSSqlServer(
                    connectionString: logDB,
                    tableName: logTable,
                    columnOptions: opts,
                    appConfiguration: Configuration
                ).CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = "https://dev-i466grcw.auth0.com/";
                options.Audience = "https://krazpizza.azurewebsites.net/api";
            });

            services.AddDbContext<Project2DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DataConnection")));
            services.AddControllersWithViews();

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://mvcpizza.azurewebsites.net/");//,
                        //"http://localhost:53101");
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();

                });
            });

            services.AddTransient<ICustomersRepo, CustomersRepo>();
            services.AddTransient<INOrdersRepo, NOrdersRepo>();
            services.AddTransient<INPizzasRepo, NPizzasRepo>();
            services.AddTransient<IBasicRepo<CheeseTypes>, CheeseTypesRepo>();
            services.AddTransient<IBasicRepo<CrustTypes>, CrustTypesRepo>();
            services.AddTransient<IBasicRepo<SauceTypes>, SauceTypesRepo>();
            services.AddTransient<IBasicRepo<Toppings>, ToppingsRepo>();
            services.AddTransient<IBasicRepo<Sides>, SidesRepo>();
            services.AddTransient<IBasicRepo<PreMadePizzas>, PreMadePizzasRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();
            
            // Use Auth0
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
