
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Provagas.WebApi
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
            services.AddMvc()
                // Adiciona as op??es do json 
                //.AddJsonOptions(options => {
                // Ignora valores nulos ao fazer jun??es nas consultas
                //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                // Ignora os loopings nas consultas
                // options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                // })


                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services
                // Define a forma de autentica??o
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                // Define os par?metros de valida??o do token
                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Quem est? solicitando
                        ValidateIssuer = true,

                        // Quem est? validando
                        ValidateAudience = true,

                        // Definindo o tempo de expira??o
                        ValidateLifetime = true,

                        // Forma de criptografia
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ProVagas.WebApi-chave-autenticacao")),

                        // Tempo de expira??o do token
                        ClockSkew = TimeSpan.FromMinutes(30),

                        // Nome da issuer, de onde est? vindo
                        ValidIssuer = "ProVagas.WebApi",

                        // Nome da audience, de onde est? vindo
                        ValidAudience = "ProVagas.WebApi"
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProVagas.WebApi", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProVagas.WebApi");
                c.RoutePrefix = string.Empty;
            });

            app.UseAuthentication();

        }
    }
}