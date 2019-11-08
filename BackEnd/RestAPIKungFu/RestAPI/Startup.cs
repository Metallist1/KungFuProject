using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KungFu.Core.ApplictionService;
using KungFu.Core.ApplictionService.HelperServices;
using KungFu.Core.ApplictionService.Service;
using KungFu.Core.DomainService;
using KungFu.Infrastructure.SQLData;
using KungFu.Infrastructure.SQLData.Repo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace RestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;

        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);

            // Add JWT based authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true, 
                    ClockSkew = TimeSpan.FromMinutes(5) 
                };
            });




            services.AddCors();
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<KungFuContext>(opt => {
                    opt.UseSqlite("Data Source=kungfuApp.db");
                }
                );
            }
            else
            {
                services.AddDbContext<KungFuContext>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            }
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepo, UserRepo>();

            services.AddTransient<IDBInit, DBInit>();
            services.AddSingleton<IAuthentication>(new Authentication(secretBytes));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    // Initialize the database
                    var services = scope.ServiceProvider;
                    var ctx = scope.ServiceProvider.GetService<KungFuContext>();
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                    var dbInitializer = services.GetService<IDBInit>();
                    dbInitializer.SeedDatabase(ctx);
                }
            }
            else
            {
             app.UseHsts();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<KungFuContext>();
                    ctx.Database.EnsureCreated();

                }
            }
            app.UseHttpsRedirection();
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
