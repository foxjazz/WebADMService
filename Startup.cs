using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebADMs.Hubs;

using WebADMs.Model;
using WebADMs.Services;

namespace WebADMs
{
    public class Startup
    {
        public static string root;
        
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            root = env.ContentRootPath;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddHttpContextAccessor();

            //var corsBuilder = new CorsPolicyBuilder();
            //corsBuilder.WithOrigins(new[] { "http://localhost:4200",
            //    "https://eveview.foxjazz.net" }); // for a specific url. Don't add a forward slash on the end!
            //corsBuilder.AllowAnyHeader();
            //corsBuilder.AllowCredentials();
            //corsBuilder.AllowAnyMethod();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            //});
            //services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy("adm",

                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200");
                        policy.AllowAnyHeader();
                        policy.AllowAnyMethod();
                    });
                    
            });

            services.AddSingleton<Repo>();
            services.AddSignalR();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.AddSingleton<IData, Data>(new Data());




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("adm");
            //app.UseCors(b =>
            //    {
            //        b.WithOrigins("http://localhost:4200", "https://eveview.foxjazz.net");
            //        //b.AllowAnyOrigin();
            //        b.AllowAnyMethod();
            //        b.AllowAnyHeader();
            //    }
            //);


            app.UseHttpsRedirection();
            
            app.UseSignalR(routes => { routes.MapHub<AdmChanges>("/admchanges"); });
            app.UseMvc();
            
        }
    }
}
