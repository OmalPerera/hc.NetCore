using System;
using HC_netCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HC_netCore
{
    public class Startup
    {

        readonly string AllowedOrigins = "_allowedOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*
            //services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TodoList"));

            // Use SQL Database if in Azure, otherwise, use SQLite
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
                services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("MasterDatabase")));
            else
                services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlite("Data Source=localdatabase.db"));

            */
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MasterDatabase")));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HC API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowedOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins(
                                          "http://localhost:3000",
                                          "https://localhost:3000"
                                          )
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.UseCors(AllowedOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Automatically perform database migration
            dbContext.Database.Migrate();


        }
    }
}
