using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VehicleApiData.DomainModels;
using Microsoft.EntityFrameworkCore;
using VehicleApiServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AutoMapper;
using VehicleApiData.Interfaces;
using VehicleApiServices.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.FileProviders;

namespace VehicleApi
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
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddAutoMapper(typeof(Startup));
            services.AddDirectoryBrowser();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "VehicleApi",
                    Description = "A simple example ASP.NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Jon-Ajumobi Olamide D.",
                        Email = "olamideajumobi@gmail.com",
                        Url = new Uri("https://twitter.com/upsidedownwf"),
                    }
                });
               // Set the comments path for the Swagger JSON and UI.

               var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddScoped<IMakes, MakesServices>();
            services.AddScoped<ILogin, LoginServices>();
            services.AddScoped<ICategories, CategoriesServices>();
            services.AddScoped<IProducts, ProductsServices>();
            services.AddScoped<IMailer, MailServices>();
            services.AddScoped(typeof(IGeneric<>), typeof(GenericServices<>));
            //services.AddScoped<IPost<Products>, PostServices<Products>>();

            services.AddDbContext<VehicleApiContext>(options => options.UseSqlServer(Configuration.GetConnectionString("VehicleConnection")));
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                                  builder =>
                                  {
                                      builder.
                                      AllowAnyOrigin()
                                                          //WithOrigins("http://localhost:*")
                                                          .AllowAnyHeader()
                                                          .AllowAnyMethod();
                                  });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //var defaultFileOptions = new DefaultFilesOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "files"))
            //};
            //defaultFileOptions.DefaultFileNames.Clear();
            //defaultFileOptions.DefaultFileNames.Add("TestDefault.html");
            //app.UseDefaultFiles(defaultFileOptions);
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "files"))
            //});
            // app.UseStaticFiles();


            //var xxxx = new FileServerOptions { EnableDirectoryBrowsing = true, FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "files")) };
            //xxxx.DefaultFilesOptions.DefaultFileNames.Clear();
            //xxxx.DefaultFilesOptions.DefaultFileNames.Add("TestDefault.html");
            //app.UseFileServer(xxxx);

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "VehicleApi");
                c.RoutePrefix = "";
            });

        }
    }
}
