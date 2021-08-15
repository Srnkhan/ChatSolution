using ChatCore.Configuration;
using ChatDb;
using ChatDb.UnitOfWork;
using ChatMvc.Hubs;
using ChatServices.Abstractions;
using ChatServices.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatMvc
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
            services.AddControllersWithViews();
            services.AddDistributedRedisCache(options =>
            {
                options.InstanceName = "RedisNetCoreSample";
                options.Configuration = ConfigurationManager.GetInstance().GetRedisConnectionString(); 
            });
            services.AddSignalR();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped<IChatService , ChatImplementation>();
            services.AddScoped<IRedisService, RedisImplementation>();
            services.AddScoped<MainDbContext>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<Chat1Hub>("/chat1hub");
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Chat}/{action=Index}/{id?}");
            });
        }
    }
}
