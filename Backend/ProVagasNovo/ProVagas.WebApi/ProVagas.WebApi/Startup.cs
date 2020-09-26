using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ProVagas.WebApi
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
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );


            services
           // Define a forma de autentica��o
           .AddAuthentication(options =>
           {
               options.DefaultAuthenticateScheme = "JwtBearer";
               options.DefaultChallengeScheme = "JwtBearer";
           })

           // Define os par�metros de valida��o do token
           .AddJwtBearer("JwtBearer", options =>
           {
               options.RequireHttpsMetadata = false;

               options.SaveToken = true;

               options.TokenValidationParameters = new TokenValidationParameters
               {
                   // Quem est� solicitando
                   ValidateIssuer = true,

                   // Quem est� validando
                   ValidateAudience = true,

                   // Definindo o tempo de expira��o
                   ValidateLifetime = true,

                   // Forma de criptografia
                   IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ProVagas-key-auth")),

                   // Tempo de expira��o do token
                   ClockSkew = TimeSpan.FromMinutes(30),

                   // Nome da issuer, de onde est� vindo
                   ValidIssuer = "ProVagas",

                   // Nome da audience, de onde est� vindo
                   ValidAudience = "ProVagas"
               };

           });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProVagas", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProVagas");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
