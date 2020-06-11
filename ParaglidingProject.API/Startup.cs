using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using ParaglidingProject.Data;
using ParaglidingProject.SL.Core;
using ParaglidingProject.SL.Core.Auth.NS;
using ParaglidingProject.SL.Core.Paraglider.NS;
using ParaglidingProject.SL.Core.Pilot.NS;
using ParaglidingProject.SL.Core.Pilot.NS.TransfertObjects;
using ParaglidingProject.SL.Core.TraineeshipPayement.NS;
using ParaglidingProject.SL.Core.Levels.NS;
using ParaglidingProject.SL.Core.Site.NS;
using ParaglidingProject.SL.Core.Flights.NS;
using ParaglidingProject.SL.Core.TraineeShip.NS.TransferObjects;
using ParaglidingProject.SL.Core.Role.NS;
using ParaglidingProject.SL.Core.TraineeShip.NS;
using ParaglidingProject.SL.Core.Possession.NS;

namespace ParaglidingProject.API
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
            
            services.AddControllers(setupAction =>
                {
                    setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status404NotFound));
                })

                // Configure Json Serializer
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });

            // Register DbContext
            var localhostCs = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ParaglidingClubContext>(options => options.UseSqlServer(localhostCs));

            // Register our Custom Services
            services.AddTransient<IPilotsService, PilotsService>();
            services.AddTransient<ITraineeshipPaymentService, TraineeshipPaymentService>();
            services.AddTransient<IParagliderService, ParagliderService>();
            services.AddTransient<ILevelsService, LevelsService>();
            services.AddTransient<ISitesService, SitesService>();
            services.AddTransient<IFlightsService, FlightsService>();
            services.AddTransient<ITraineeShipService, TraineeShipService>();
            services.AddTransient<IPossessionsService, PossessionsService>();
            services.AddTransient<IRoleService, RolesService>();
            services.AddTransient<IAuthService, AuthService>();

            // Safe JWT secret key injection
            var appSettingsSection = Configuration.GetSection("JwtSign");
            services.Configure<AppSettings>(appSettingsSection);

            // JWT Authentication Pipeline
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(ao =>
                {
                    ao.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    ao.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(jbo =>
                {
                    jbo.RequireHttpsMetadata = true;
                    jbo.SaveToken = true;
                    jbo.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "JWT"
                            }
                        }, new List<string>()
                    }
                });

                setupAction.SwaggerDoc(
                    "authentication",
                    new OpenApiInfo()
                    {
                        Title = "Authentication",
                        Version = "v1",
                    });

                setupAction.SwaggerDoc(
                    "pilots",
                    new OpenApiInfo()
                    {
                        Title = "Pilots",
                        Version = "v1"
                    });

                setupAction.SwaggerDoc(
                    "flight",
                    new OpenApiInfo()
                    {
                        Title = "Flights",
                        Version = "v1"
                    });


                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
                setupAction.IncludeXmlComments(xmlCommentsFullPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint(
                    "/swagger/pilots/swagger.json",
                    "Pilots");
                setupAction.SwaggerEndpoint(
                    "/swagger/authentication/swagger.json",
                    "Authentication");
                setupAction.SwaggerEndpoint(
                    "/swagger/flight/swagger.json",
                    "Flight");
                setupAction.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}