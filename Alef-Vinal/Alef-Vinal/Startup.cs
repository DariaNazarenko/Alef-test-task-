using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Alef_Vinal.DataAccess.Domain;
using Alef_Vinal.DataAccess.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Alef_Vinal.Services.DTOs;
using Alef_Vinal.Services.Validation;
using Alef_Vinal.Services.Services.Interfaces;
using Alef_Vinal.Services.Services;

namespace Alef_Vinal
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

            var cs = Configuration.GetConnectionString("DatabaseConnectionString");
            services.AddDbContext<Alef_VinalContext>(options => options.UseSqlServer(cs));
            services.AddTransient<IUnitOfWork, UnitOfWork>(e => new UnitOfWork(e.GetService<Alef_VinalContext>()));

            services.AddTransient<IValidator<ValueCodeDto>, ValueCodeValidator>();
            services.AddTransient<ICodeService, CodeService>();

            services.AddControllersWithViews().AddNewtonsoftJson();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Alef_VinalContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            context.EnsureCreated();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
