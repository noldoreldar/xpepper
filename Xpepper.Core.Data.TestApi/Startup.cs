using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xpepper.Core.Data.EF;
using Xpepper.Core.Data.EF.SqlServer;
using Xpepper.Core.Data.MongoDb;

namespace Xpepper.Core.Data.TestApi
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
            services.AddControllers();
            services.AddSingleton(provider => Configuration);

            var dbConfig = Configuration.GetSection("SqlDbConfiguration").Get<DbContextConfiguration>();
            services.AddUnitOfWork<DbUnitOfWork<TestContext>, DbContextConfiguration>(dbConfig);

            //var dbConfig = Configuration.GetSection("MongoDbConfiguration").Get<MongoDbConfiguration>();
            //services.AddUnitOfWork<MongoDbUnitOfWork, MongoDbConfiguration>(dbConfig);
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
