using API.AutoMapper;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SHS.Application.AreaAppService;
using SHS.Application.ArticleAppService;
using SHS.Application.AutoMapper;
using SHS.Application.CategoryAppService;
using SHS.Application.PermissionAppService;
using SHS.Application.RoleAppService;
using SHS.Application.TagAppService;
using SHS.Application.UserAppService;
using SHS.Domain.Repository.Interfaces;
using SHS.Infra.Data;
using SHS.Service.AreaService;
using SHS.Service.ArticleService;
using SHS.Service.CategoryService;
using SHS.Service.PermissionService;
using SHS.Service.RoleService;
using SHS.Service.TagService;
using SHS.Service.UsersService;
using System;
using System.Collections.Generic;

namespace API
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //引用跨域
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder => builder.WithOrigins("http://localhost:9528")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddMvc(options => { options.EnableEndpointRouting = false; });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfigs());
                mc.AddProfile(new ModelToDtoAutoMapperConfig());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            //var configuration = new MapperConfiguration(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies().GetType()));

            //IMapper mapper = new Mapper(configuration);
            services.AddSingleton(mapper);
            //Configuration.GetConnectionString(
            services.AddDbContext<CMSContext>(option => option.UseSqlServer(@"Server=.\sqlexpress;uid=shs;pwd=123456;database=SHS.CMS;"));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //services.AddScoped(AppDomain.CurrentDomain.GetAssemblies().GetType());

            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleAppService, RoleAppService>();

            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IArticleAppService, ArticleAppService>();

            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IPermissionAppService, PermissionAppService>();

            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ITagAppService, TagAppService>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryAppService, CategoryAppService>();

            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IAreaAppService, AreaAppService>();
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
    }
}
