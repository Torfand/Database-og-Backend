using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewsLetter.Core._1_Application_Services;
using NewsLetter.Core._2_Domain_Services;
using NewsLetter.Core._3_Domain_Model;
using NewsLetter.Infrastructure.DataAcsess;

namespace NewsLetter.Infrastructure.Api
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
            var value = Configuration.GetConnectionString("NewsLetterDB");
            var connectionString = new ConnectionString(value);
            services.AddSingleton<ConnectionString>(connectionString);
            services.AddControllers();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<SubscriptionService>();
            services.AddSwaggerDocument();

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
            app.UseStaticFiles();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
