using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using PolityczneSpektrum.Data;
using PolityczneSpektrum.Services;
using ReflectionIT.Mvc.Paging;
using System.IO;

namespace PolityczneSpektrum
{
    public class Startup
    {
        private IConfiguration _configuration;

        public CompatibilityVersion CompatibilityVersion_2_1 { get; private set; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<PolityczneSpektrumDbContext>(x => x.UseSqlite(_configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<PolityczneSpektrumDbContext>(opt =>
            //opt.UseSqlServer(_configuration.GetConnectionString("PolityczneSpektrum")));
            services.AddScoped<IQuestionsData, SqlQuestionsData>();

            services.AddMvc()
    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
    .AddSessionStateTempDataProvider();

            services.AddSession();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseCors(x => x.AllowAnyOrigin().AllowAnyOrigin().AllowAnyHeader());
            app.UseCors(config => config.WithOrigins("http://localhost:5000").AllowAnyHeader().AllowAnyMethod());

            app.UseStaticFiles();

            app.UseNodeModules(env.ContentRootPath);

            app.UseMvc(ConfigureRoutes);

            app.UseSession();

            app.UseWelcomePage(new WelcomePageOptions
            {
                Path="/wp"
            });

            // This will add "Libs" as another valid static content location
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                     Path.Combine(Directory.GetCurrentDirectory(), @"Imgs")),
                RequestPath = new PathString("/Imgs")
            });
   

        }

        private void ConfigureRoutes(IRouteBuilder obj)
        {
            // /Home/Index/4

            obj.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
