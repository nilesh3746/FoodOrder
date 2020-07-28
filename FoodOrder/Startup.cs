using FoodOrder.Persistence.EntityFrameworkCore;
using FoodOrder.Persistence.Repositories;
using FoodOrder.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using AspNetCore.ServiceRegistration.Dynamic.Extensions;
using AspNetCore.ServiceRegistration.Dynamic.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using FoodOrder.Controllers;
using FoodOrder.Models;
using Microsoft.AspNetCore.Http;

namespace FoodOrder
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

            services.AddDbContext<FoodDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            
            //Register IHttpContextService
            services.AddHttpContextAccessor();

            //Authentication, Identity config
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<FoodDbContext>();

            //Auto Mapper
            services.AddAutoMapper(typeof(Startup));

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            //services.AddServicesOfType<IScopedService>();
            services.AddServicesWithAttributeOfType<ScopedServiceAttribute>();
            services.AddScoped<ShoppingCartSession>();

            services.AddMvc(config => {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddMemoryCache();
            services.AddSession();
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
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
