using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContactSync.BusinessLogic;
using ContactSync.Context;
using ContactSync.Data;
using ContactSync.IBusinessLogic;
using ContactSync.IRepository;
using ContactSync.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ContactSync.Api
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
            services.AddMvc();

            services.AddDbContext<ContactSyncContext>(db => db.UseInMemoryDatabase());

            // Repository Services
            services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();

            // Business Logic Services
            services.AddScoped<IPhoneBookBusinessLogic, PhoneBookBusinessLogic>();
            services.AddScoped<IPhoneBookEntryBusinessLogic, PhoneBookEntryBusinessLogic>();

            services.AddTransient<ContactSyncSeedData>();

            services.AddAutoMapper();

            services.AddSwaggerGen(sg =>
            {
                sg.SwaggerDoc("v1", new Info { Title = "Contact Sync Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<ContactSyncSeedData>();
                    seeder.Seed();
                }
            }

            app.UseSwagger();

            app.UseSwaggerUI(sui =>
            {
                sui.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact Sync Api");
                sui.RoutePrefix = string.Empty;
                sui.DocExpansion(DocExpansion.None);
            });

            app.UseMvc();
        }
    }
}
