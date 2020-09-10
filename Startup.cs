using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DIWebApplication
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
            services.AddSingleton<ILog, ConsoleLogger>();
            //services.AddSingleton<ILog, FileLogger>();

            //.Net Core Built in DI, registered as a Singleton (default), 
            //Creates a singleton object of ConsoleLogger and injects it into constructor of classes wherever we use ILog.
            //Automatically  disposes of object.
            /*
                The built-in IoC container supports three kinds of lifetimes:

                Transient: The IoC container will create a new instance of the specified service type every time you ask for it. This lifetime works best for lightweight, stateless services.
                Scoped: IoC container will create an instance of the specified service type once per client request (connection) and will be shared in a single request.
                services.AddDbContext<InventoryContext> uses scoped lifetime in entity framework.
                Singleton: IoC container will create and share a single instance of a service throughout the application's lifetime. Every subsequent request uses the same instance.

            */
            //services.Add(new ServiceDescriptor(typeof(ILog), new ConsoleLogger())); // singleton
            //services.AddSingleton<ILog, ConsoleLogger>(); //Extension methods for each!

            //services.Add(new ServiceDescriptor(typeof(ILog), typeof(ConsoleLogger), ServiceLifetime.Transient)); // Transient
            //services.AddTransient<ILog, ConsoleLogger>();

            //services.Add(new ServiceDescriptor(typeof(ILog), typeof(ConsoleLogger), ServiceLifetime.Scoped));    // Scoped
            //services.AddScoped<ILog, ConsoleLogger>();

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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
