using MediatR;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

using System.Reflection;
using Velosklad.Extensions;
using Velosklad.Core.Products;

namespace Velosklad
{
    public class Startup
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMediatR(GetMediatrAssemblies().ToArray());

            services.AddDatabase(_configuration);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSwagger()
                .UseSwaggerUI(options =>
                {
                    
                });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private IEnumerable<Assembly> GetMediatrAssemblies()
        {
            yield return Assembly.GetAssembly(typeof(CreateProduct.Request))!;
        }
    }
}
