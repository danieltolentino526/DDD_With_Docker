using Autofac.Extensions.DependencyInjection;
using Hellang.Middleware.ProblemDetails;
using Infra.Context;
using Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApi.Filters;
using WebApi.Swagger;

[assembly: ApiConventionType(typeof(ApiConventions))]
namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(Environment.GetEnvironmentVariable("TEST_CONN")));

            services.ConfigureSwaggerDocument();

            services.AddProblemDetails();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(NotificationFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            return new AutofacServiceProvider(services.ConfigureContainer<Startup>());
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.ConfigureServiceSwagger();

            app.UseProblemDetails();

            app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto });

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
