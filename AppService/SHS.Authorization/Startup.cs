using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SHS.Infra.Data;
using System;

namespace SHS.Authorization
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // configure identity server with in-memory stores, keys, clients and scopes
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(Config.GetIdentityResourceResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                .AddProfileService<ProfileService>();
            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.AllowAnyOrigin(); //允许任何来源的主机访问
                    builder.WithOrigins("http://localhost:5000") ////允许http://localhost:8080的主机访问
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();//指定处理cookie

                });
            });
            //services.AddDbContext<CMSContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("SqlServerContext")));
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //配置跨域处理，允许所有来源：
            app.UseCors("any");
            app.UseIdentityServer();
        }
    }
}
