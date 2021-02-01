using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AshrafsBookStore.Models.DataLayer.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AshrafsBookStore
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
            services.AddRouting(opt => opt.LowercaseUrls = true);
            services.AddMemoryCache();
            services.AddSession();
            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddDbContext<BookStoreContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("BookStoreContext"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "admin",
                    areaName: "Admin",
                    pattern: "Admin/{Controller=Book}/{action=Index}/{id?}"
                );

                //Route For Paging Sorting and Filtering
                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "{Controller}/{action}/page/{pagenumber}/size/{pagesize}/sort/{sortfield}/filter/{author}/{genre}/{price}"
                );

                //Route For Paging and Sorting
                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "{Controller}/{action}/page/{pagenumber}/size/{pagesize}/sort/{sortfield}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");
            });
        }
    }
}
