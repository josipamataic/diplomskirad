using Diplomski.Server.Data;
using Diplomski.Server.Data.Models;
using Diplomski.Server.Features.Identity;
using Diplomski.Server.Features.Oglasi;
using Diplomski.Server.Features.Prijave;
using Diplomski.Server.Features.Profili;
using Diplomski.Server.Features.Search;
using Diplomski.Server.Infrastructure.Filters;
using Diplomski.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Server.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static AppSettings GetApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettings = configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(applicationSettings);

            return applicationSettings.Get<AppSettings>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<DiplomskiDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetDefaultConnection()));

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<DiplomskiDbContext>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, AppSettings appSettings)
        {
            
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };

                });

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            =>
            services.AddTransient<IIdentityService, IdentityService>()
                .AddScoped<ICurrentUserService, CurrentUserService>()
                .AddTransient<IKandidatProfilService, KandidatProfilService>()
                .AddTransient<IPoslodavacProfilService, PoslodavacProfilService>()
                .AddTransient<IOglasService, OglasService>()
                .AddTransient<ISearchService, SearchService>()
                .AddTransient<IPrijavaService, PrijavaService>();
                        

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        =>
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Jobs API", Version = "v1" });
            });

        public static void AddApiControllers(this IServiceCollection services)
            => services
            .AddControllers(options => options
            .Filters
            .Add<ModelOrNotFoundActionFilter>());
            
           
    }
}
