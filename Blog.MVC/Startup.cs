using Blog.DataAccess.Context;
using Blog.DataAccess.Repositories;
using Blog.DataAccess.Contracts.Repositories;
using Blog.MVC.Settings;
using Blog.Services.Posts;
using Blog.Services.Contracts.Posts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Blog.MVC
{
    public class Startup
    {
        private IConfiguration Config;

        public Startup(IHostingEnvironment env)
        {
            Config = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange:true)
                .AddEnvironmentVariables()
                .Build();   
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            services.AddOptions();

            services.AddTransient<IPostService, PostService>();

            ConfigureDatabase(services);
            services.AddTransient<IRepository, EfRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(x => 
                x.MapRoute(name: "default",
                           template: "{controller=Home}/{action=Index}/{Id?}")
            );
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            var useSQLite = Config.GetValue<bool>("Database:UseSQLite");

            if(useSQLite)
            {
                var connectionString = Config.GetValue<string>("Database:ConnectionStrings:SQLiteConnectionString");
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
            }
            else
            {
                var connectionString = Config.GetValue<string>("Database:ConnectionStrings:SQLConnectionString");
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            }
        }
    

    }
}
