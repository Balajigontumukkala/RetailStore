using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RetailStore.Api.MetaDataBL.Category;
using RetailStore.Api.MetaDataBL.Department;
using RetailStore.Api.MetaDataBL.Location;
using RetailStore.Api.MetaDataBL.Login;
using RetailStore.Api.MetaDataBL.Login.Models;
using RetailStore.Api.MetaDataBL.Repository;
using RetailStore.Api.MetaDataBL.SkuDetails;
using RetailStore.Api.MetaDataBL.Subcategory;
using RetailStore.ClientConfiguration;

namespace RetailStore.Api.Root
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            this.Configuration = configuration;

            new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var clientSettings = new ClientSettings();
            this.Configuration.GetSection("ClientSetting").Bind(clientSettings);
            var cors = clientSettings.CorsOrigins.Split(',');
            ClientConfiguration.ClientConfiguration.ClientSettings = clientSettings;            
            services.AddTransient(typeof(MetaDataDBContext));
            services.AddTransient(typeof(ILocationManager), typeof(LocationManager));
            services.AddTransient(typeof(IDepartmentManager), typeof(DepartmentManager));
            services.AddTransient(typeof(ICategoryManager), typeof(CategoryManager));
            services.AddTransient(typeof(ISubcategoryManager), typeof(SubcategoryManager));
            services.AddTransient(typeof(ILoginManager), typeof(LoginManager));
            services.AddTransient(typeof(ISkuDetailsManager), typeof(SkuDetailsManager));
            services.AddDbContext<MetaDataDBContext>(options => options.UseSqlServer(clientSettings.AppConnectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                  .AddEntityFrameworkStores<MetaDataDBContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = clientSettings.RequireHttpsMetadata;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(clientSettings.Token.Key)),
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidIssuer = clientSettings.Token.Issuer,
                    ValidateLifetime = true,
                    ValidAudience = clientSettings.Token.Audience,
                    ValidateAudience = true
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors(o => o.AddPolicy("Cors", builders =>
            {
                builders.WithOrigins(cors)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            }));

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseCors("Cors");

            //Addd User session
            app.UseSession();

            //Add JWToken to all incoming HTTP Request Header
            app.Use(async (context, next) =>
            {
                var JWToken = context.Session.GetString("UserToken");
                if (!string.IsNullOrEmpty(JWToken))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
                }
                await next();
            });

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
