using MediatR;
using System.Reflection;
using Velosklad.Core.Handlers;

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

            services.AddMediatR(GetMediatrAssembly());

            services.AddSingleton<CreateProductHandler>();

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        private Assembly[] GetMediatrAssembly()
        {
            throw new NotImplementedException();
        }
    }
}
