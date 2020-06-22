using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieLib.API.Initialization.ConfigureApplication;
using MovieLib.API.Initialization.ConfigureServices;
using MovieLib.BL;
using SimpleInjector;

namespace MovieLib.API
{
    public class Startup
    {
        private readonly Container _container = new Container();
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPersistenceConfiguration(Configuration);
            services.AddIdentityConfiguration();

            services.AddControllers();

            services.AddSwaggerConfiguration();

            services.AddLogging();
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddSimpleInjectorConfiguration(_container);
            
            services.AddCors();
            
            services.AddAutoMapper((provider, expression) => expression.AddAutoMapperConfiguration()
                , typeof(Startup).Assembly);
            services.AddBusinessLogic(_container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
                app.UseHttpsRedirection();

            app.UseExceptionHandlerWithJsonResponse();

            app.UseRouting();

            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3();
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}