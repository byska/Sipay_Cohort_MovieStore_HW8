using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sipay_Cohort_MovieStore.Business.Mapping;
using Sipay_Cohort_MovieStore.Business.Middlewares;
using Sipay_Cohort_MovieStore.Business.Services.Actor;
using Sipay_Cohort_MovieStore.Business.Services.Customer;
using Sipay_Cohort_MovieStore.Business.Services.Director;
using Sipay_Cohort_MovieStore.Business.Services.Logger;
using Sipay_Cohort_MovieStore.Business.Services.Movie;
using Sipay_Cohort_MovieStore.Business.Services.Purchased;
using Sipay_Cohort_MovieStore.Business.Services.Token;
using Sipay_Cohort_MovieStore.Core.JWT;
using Sipay_Cohort_MovieStore.DataAccess.Context;
using Sipay_Cohort_MovieStore.DataAccess.UnitOfWork;
using Sipay_Final.Business.Services.Token;
using System.Text;

namespace Sipay_Cohort_MovieStore.Api
{ 
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static JwtConfig JwtConfig { get; private set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            JwtConfig = Configuration.GetSection("JwtConfig").Get<JwtConfig>();
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie Store", Version = "v1" });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Sim Management for IT Company",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {securityScheme, new string[] { }}
            });
            });

            //dbcontext
            var dbType = Configuration.GetConnectionString("DbType");
            if (dbType == "Sql")
            {
                var dbConfig = Configuration.GetConnectionString("MsSqlConnection");
                services.AddDbContext<MovieStoreDbContext>(opts =>
                opts.UseSqlServer(dbConfig));
            }


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = JwtConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtConfig.Secret)),
                    ValidAudience = JwtConfig.Audience,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(2)
                };
            });
            services.AddScoped<IUow, Uow>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(config.CreateMapper());



            services.AddTransient<ILoggerService, LoggerService>();
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDirectorService, DirectorService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IPurchasedService, PurchasedService>();
            services.AddScoped<ITokenService, TokenService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieStore v1"));
            }

            app.UseHttpsRedirection();

            //Global Exception Handler
            app.UseCustomExceptionMiddle();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
