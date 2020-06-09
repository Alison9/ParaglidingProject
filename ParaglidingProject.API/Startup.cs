using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using ParaglidingProject.Data;

using ParaglidingProject.SL.Core.Paraglider.NS;
using ParaglidingProject.SL.Core.Pilot.NS;

using ParaglidingProject.SL.Core.TraineeshipPayement.NS;
using ParaglidingProject.SL.Core.Levels.NS;
using ParaglidingProject.SL.Core.Site.NS;
using ParaglidingProject.SL.Core.Flights.NS;

using ParaglidingProject.SL.Core.Role.NS;
using ParaglidingProject.SL.Core.TraineeShip.NS;
using ParaglidingProject.SL.Core.Possession.NS;
using ParaglidingProject.SL.Core.Subscription.NS;

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
            services.AddControllers()

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
            services.AddTransient<ISubscriptionService, SubscriptionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
