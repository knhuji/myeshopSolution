
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using EasyCaching.Core.Configurations;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using myeshop.Application.System.Users;
using myeshop.Data.EF;
using Microsoft.Extensions.Caching.Distributed;
using myeshop.Data.Entities;
using myeShop.Utilities.Constants;
using myeShop.ViewModels.System.Users;
using Swashbuckle.AspNetCore.SwaggerGen;
using myeshop.Application.Catalog.Products;
using myeshop.Application.Common;
using myeshop.Application.Catalog.Carts;
using StackExchange.Redis;
using Microsoft.CodeAnalysis.Options;
using myeshop.Application.Catalog.Suppliers;

using Microsoft.AspNetCore.Mvc;
using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using myeshop.Application.System.Roles;


namespace myeShop.BackendApi
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

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(SystemConstants.MainConnectionString)));
            services.AddIdentity<User, Role>()
                 .AddEntityFrameworkStores<DataContext>()
                 .AddDefaultTokenProviders();
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());

            services.AddControllersWithViews();


            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger mye shop", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });


                string issuer = Configuration.GetValue<string>("Tokens:Issuer");
                string signingKey = Configuration.GetValue<string>("Tokens:Key");
                byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

                services.AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = issuer,
                        ValidateAudience = true,
                        ValidAudience = issuer,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = System.TimeSpan.Zero,
                        IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                    };
                });
            });
            //services.AddMemoryCache();
            //services.AddStackExchangeRedisCache(Options =>
            //{
            //    Options.Configuration = "https://localhost:5001,password=rediskey,ssl=True,abortConnect=False";
            //    Options.InstanceName = "master";
            //});

            services.AddEasyCaching(options =>
            {
                //use redis cache
                options.UseRedis(redisConfig =>
                {
                    //Setup Endpoint
                    redisConfig.DBConfig.Endpoints.Add(new ServerEndPoint("localhost", 6379));

                    //Setup password if applicable
                    //if (!string.IsNullOrEmpty(serverPassword))
                    //{
                    //    redisConfig.DBConfig.Password = serverPassword;
                    //}

                    //Allow admin operations
                    redisConfig.DBConfig.AllowAdmin = true;
                },
                    "redis1");
            });



            //services.AddSingleton<ConnectionMultiplexer>(sp =>
            //{

            //    var configuration = ConfigurationOptions.Parse(("127.0.0.1"), true);
            //    configuration.ResolveDns = true;
            //    configuration.AbortOnConnectFail = false;
            //    return ConnectionMultiplexer.Connect(configuration);
            //});

            //services.AddSignalR().AddStackExchangeRedis("https://localhost:5003");

            services.AddTransient<IStorageService, FileStorageService>();

            services.AddTransient<UserManager<User>, UserManager<User>>();
            services.AddTransient<SignInManager<User>, SignInManager<User>>();
            services.AddTransient<RoleManager<Role>, RoleManager<Role>>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IRoleService, RoleService>();

            //services.AddTransient < IValidator<LoginRequest>, LoginRequestValidator >();
            //services.AddTransient<IValidator<RegisterRequest>, RegisterRequestValidator>();



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
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger mye shop v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}