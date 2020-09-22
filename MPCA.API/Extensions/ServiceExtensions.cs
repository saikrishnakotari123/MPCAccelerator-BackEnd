#region Namespace
using MPCA.Contracts;
using MPCA.Entities;
using MPCA.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MPCA.LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text; 
#endregion

namespace MPCA.API.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configures the cors.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        /// <summary>
        /// Configures the IIS integration.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }
        /// <summary>
        /// Configures the SQL context.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="config">The configuration.</param>
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connection = config.GetConnectionString("MPCADatabase");
            services.AddDbContextPool<RepositoryContext>(options => options.UseSqlServer(connection));
        }

        /// <summary>
        /// Configures the logger service.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        /// <summary>
        /// Configures the repository wrapper.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        /// <summary>
        /// Configures the authentication.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="config">The configuration.</param>
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = config["Jwt:Audience"],
                    ValidIssuer = config["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
                };
            });
        }
        public static void ConfigureAuthorization(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanReadTenant",policy => policy.RequireRole("SuperAdministrator","SuperManager", "Administrator"));
                options.AddPolicy("CanWriteTenant", policy => policy.RequireRole("SuperAdministrator", "SuperManager"));
                options.AddPolicy("CanDeleteTenantX", policy => policy.RequireRole("SuperAdministrator", "SuperManager"));
            });

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            //{
            //    options.RequireHttpsMetadata = false;
            //    options.SaveToken = true;
            //    options.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidAudience = config["Jwt:Audience"],
            //        ValidIssuer = config["Jwt:Issuer"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
            //    };
            //});
        }
    }
}
