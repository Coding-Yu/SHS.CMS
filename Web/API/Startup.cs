using API.AutoMapper;
using API.Filter;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SHS.Application.AutoMapper;
using SHS.Domain.Repository.Interfaces;
using SHS.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace API
{
    public class Startup
    {

        public IConfiguration _configuration { get; set; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //引用跨域
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder => builder.WithOrigins(_configuration["WebHost:CrossDomain:URL"])
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddMvc(
                options =>
                {
                    options.EnableEndpointRouting = false;
                    options.Filters.Add(typeof(GlobalExceptionFilter));
                    options.Filters.Add(typeof(RequestActionFilter));
                }
                );
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfigs());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            //var configuration = new MapperConfiguration(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies().GetType()));

            //IMapper mapper = new Mapper(configuration);
            services.AddSingleton(mapper);
            //Configuration.GetConnectionString(
            services.AddDbContext<CMSContext>(option => option.UseSqlServer(_configuration["DBConfig:MSSQL:ConnectionString"]));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            foreach (var item in GetClassName("SHS.Application"))
            {
                foreach (var typeArray in item.Value)
                {
                    services.AddScoped(typeArray, item.Key);
                }
            }
            foreach (var item in GetClassName("SHS.Service"))
            {
                foreach (var typeArray in item.Value)
                {
                    services.AddScoped(typeArray, item.Key);
                }
            }
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SHS.CMS API", Version = "v1" });
                // Add security definitions
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Please enter into field the word 'Bearer' followed by a space and the JWT value",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });
                c.OperationFilter<AddAuthTokenHeaderParameter>();
                //c.ResolveConflictingActions(apiDescriptions => apiDescriptions.());
            });
            services.AddMvcCore()
            .AddAuthorization()
            .AddNewtonsoftJson();

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;
                    options.Audience = "api";
                    // 多长时间来验证以下 Token
                    options.TokenValidationParameters.ClockSkew = TimeSpan.FromMinutes(60);
                    // 我们要求 Token 需要有超时时间这个参数
                    options.TokenValidationParameters.RequireExpirationTime = true;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //设置全局跨域
            //app.UseCors(builder => builder
            //    .AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .AllowCredentials());
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SHS.CMS API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc();

        }
        public Dictionary<Type, Type[]> GetClassName(string assemblyName)
        {
            var result = new Dictionary<Type, Type[]>();
            if (!string.IsNullOrWhiteSpace(assemblyName))
            {
                Assembly assembly = Assembly.Load(assemblyName);
                List<Type> list = assembly.GetTypes().ToList();
                list = list.Where(x => x.Name.Contains("Service")).ToList();
                foreach (var item in list.Where(s => !s.IsInterface))
                {
                    var interfaceType = item.GetInterfaces();
                    result.Add(item, interfaceType);
                }
            }
            return result;
        }
    }
}
