using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Qualite.Ingenieria.App.Users;
using Qualite.Ingenieria.Authentication.Auth;
using Qualite.Ingenieria.Authentication.Http;
using Qualite.Ingenieria.Data;
using Qualite.Ingenieria.Data.DapperMapper.Users;
using Qualite.Ingenieria.Data.Settings;
using Qualite.Ingenieria.Domain.Entities.Users;
using Qualite.Ingenieria.Domain.Services.Users;
using Qualite.Ingenieria.Domain.UnitOfWork;
using Qualite.Ingenieria.Services.Users;
using System.Diagnostics.CodeAnalysis;

namespace Qualite.Ingenieria.IoC
{
    [ExcludeFromCodeCoverage]
    public static class RegisterDependencies
    {
        public static void Register(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IDbConnection>(ctx => new MySqlConnection(configuration.GetConnectionString("DefaultConnection")));
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped<IUserRepository, UserRepository>();
            services.Configure<DataBaseSettings>(configuration.GetSection("MysqlSettings"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserApp, UserApp>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            /* Registering Dapper Mappings */
            RegisterMappings();
        }

        public static void AddQualiteAuthentication(this IServiceCollection services)
        {
            var authenticationBuilder = services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = QualiteAuthenticationDefaults.AuthenticationScheme;
                options.DefaultScheme = QualiteAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = QualiteAuthenticationDefaults.ExternalAuthenticationScheme;
            });

            authenticationBuilder.AddCookie(QualiteAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.Cookie.Name = $"{QualiteCookieDefaults.Prefix}{QualiteCookieDefaults.AuthenticationCookie}";
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.LoginPath = QualiteAuthenticationDefaults.LoginPath;
                options.AccessDeniedPath = QualiteAuthenticationDefaults.AccessDeniedPath;
            });
        }

        private static void RegisterMappings()
        {
            FluentMapper.Initialize(config => 
            {
                config.AddMap(new UserMap());
                config.ForDommel();
            });
        }
    }
}
