using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaKPI_API.Context;

namespace SistemaKPI_API
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

            // ContextoKPI
            services.AddDbContext<SistemaKPIContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // ContextContpaq
            services.AddDbContext<ContpaqContext>(o => o.UseSqlServer(Configuration.GetConnectionString("ContpaqConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                builder =>
                {
                    builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("AllowAll");
            }

            app.UseMvc();
        }
    }
}
