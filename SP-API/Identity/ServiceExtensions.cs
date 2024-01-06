using Application.Wrappers;
using Domain.Settings;
using Identity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Persistence.Context;
using System.Text;

namespace Identity
{
    public static class ServiceExtensions
    {
        public static void AddIdentityInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = true;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JWTSettings:Issuer"],
                    ValidAudience = configuration["JWTSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"]))
                };

                o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = o =>
                    {
                        o.NoResult();
                        o.Response.StatusCode = 500;
                        o.Response.ContentType = "text/plain";
                        return o.Response.WriteAsync(o.Exception.ToString());
                    },
                    OnChallenge = o =>
                    {
                        o.HandleResponse();
                        o.Response.StatusCode = 401;
                        o.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(new Response<string>("No se cuenta con autorización"));
                        return o.Response.WriteAsync(result);
                    },
                    OnForbidden = o => {
                        o.Response.StatusCode = 400;
                        o.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(new Response<string>("No se tienen permisos para acceder a este recurso"));
                        return o.Response.WriteAsync(result);
                    }
                };

            });

        }
    }
}
