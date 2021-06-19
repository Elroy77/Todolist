using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServers.Data;
using Microsoft.EntityFrameworkCore;
using WebServers.Repositories;
using WebServers.Repositories.Tasks;

namespace WebServers
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo { Title = "Todolist", Version = "V1" });
            });
            services.AddDbContext<TodolistDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
            });
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddCors(options => 
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed(host => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
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
            app.UseCors("CorsPolicy");
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "Todolist");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
