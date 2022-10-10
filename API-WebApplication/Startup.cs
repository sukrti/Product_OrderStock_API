using GlobalExceptionHandling.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using APIBusinessLogic.Orders;
using APIBusinessLogic.Stocks;
using APIBusinessLogic.Orders.Contracts;
using APIBusinessLogic.Stocks.Contracts;

namespace API_WebApplication
{
    /// <summary>
    /// This class sets up middleware and configure services
    /// </summary>
    public class Startup
    {
        #region Fields
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Methods

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductOrderService, ProductOrderServices>();
            services.AddScoped<IProductStockService, ProductStockService>();    
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_WebApplication", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_WebApplication v1"));
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        #endregion
    }
}
