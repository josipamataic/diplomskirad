using Diplomski.Server.Data;
using Diplomski.Server.Data.Models;
using Diplomski.Server.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Server
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
            //  services.AddCors();

            /*var applicationSettings = this.Configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(applicationSettings);

            var appSettings = services.GetApplicationSettings(this.Configuration);*/

            services.AddDatabase(this.Configuration)
                .AddIdentity()
                .AddJwtAuthentication(services.GetApplicationSettings(this.Configuration))
                .AddApplicationServices()
                .AddSwagger()
                .AddApiControllers();


            //services.AddDatabaseDeveloperPageExceptionFilter();          


            /*  var key = Encoding.ASCII.GetBytes(appSettings.Secret);

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

                  });*/

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
           
            app.UseSwaggerUI()
                .UseRouting();

            app.UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            CreateUserRoles(services).Wait();

            app.ApplyMigrations();

            
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();

            IdentityResult roleResult;

            //adding Poslodavac role
            var roleCheckPoslodavac = await RoleManager.RoleExistsAsync("Poslodavac");
            var roleCheckKandidat = await RoleManager.RoleExistsAsync("Kandidat");

            if (!roleCheckPoslodavac)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Poslodavac"));
            }
            if (!roleCheckKandidat)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Kandidat"));
            }
        }
    }
}
