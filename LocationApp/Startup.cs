using Microsoft.AspNetCore.Builder;

namespace LocationApp
{
    public class Startup
    {
        public IConfiguration configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            
            services.AddMvc();
            services.AddSingleton(provider => configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {

            
            //app.UseRuntimeInfoPage();

            app.UseFileServer();

            app.UseMvc(ConfigureRoutes);

            
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=LocationController}/{action=Index}/{id?}");
        }
    }
}

