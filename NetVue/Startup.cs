using System;
using System.Text;
using BAL;
using DAL;
using IBAL;
using IDAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;

namespace NetVue
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true, // 是否验证 Issuer
                        ValidateAudience = true, // 是否验证 Audience
                        ValidateLifetime = true, // 是否验证失效时间
                        ValidateIssuerSigningKey = true, // 是否验证 SecurityKey
                        ValidAudience = "nechao", // Audience
                        ValidIssuer = "nechao", // Issuer，这两项和后面签发 jwt 的设置一致
                        ClockSkew = TimeSpan.Zero, // 默认允许 300s  的时间偏移量，设置为 0
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nechaonechaonechao")) //拿到 SecurityKey
                    };
                });
            services.AddControllersWithViews().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
            // In production, the vue files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "wwwroot"; });

            services.AddTransient<IDAL_User, DAL_User>();
            services.AddTransient<IBAL_User, BAL_User>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                if (env.IsDevelopment())
                    // 本地调试配置，不要 commit
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:6666");
            });
        }
    }
}