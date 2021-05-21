using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Market.Persistance;
using Market.Infrastructure.Service;
using Market.Domain.Repositories.Products;

namespace Market.Api
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
            //services.AddAutoMapper(typeof(MappingProfile));
            //services.AddTransient<IProductRepository, ProductRepository>();

            services.AddDbContext<DB_MARKETContext>(options =>
                           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

           // services.AddScoped<IProductRepository,ProductRepository>();

            services.AddTransient<ProductService>();
            services.AddTransient<ProductRepository>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
