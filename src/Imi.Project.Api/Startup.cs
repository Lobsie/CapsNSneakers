using Imi.Project.Api.Core.Constants;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Services;
using Imi.Project.Api.Infrastructure.Data;
using Imi.Project.Api.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Imi.Project.Api
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
            // Add dbcontext
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PRI-Duyck-Gijs")));

            // Identity Configuration
            services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllers();

            // Add swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Caps-N-Sneakers API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new[] { "Bearer" }
                    }
                });
            });

            services.AddScoped<ICapRepository, CapRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IFittingRepository, FittingRepository>();

            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IFittingService, FittingService>();
            services.AddScoped<ICapService, CapService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddHttpContextAccessor();

            // Add AuthenticationService
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidAudience = Configuration["Jwt:ValidAudience"],
                    ValidIssuer = Configuration["Jwt:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SigningKey"]))
                };
            });

            // Add Authorization
            services.AddAuthorization(options =>
            {
                options.AddPolicy(CustomPolicies.CanRead, policy =>
                {
                    policy.RequireAssertion(context =>
                    {
                        if (context.User.IsInRole(CustomRoles.Admin))
                            return true;

                        return context.User.HasClaim(CustomClaimTypes.HasApproved, "True") && context.User.IsInRole(CustomRoles.User);
                    });
                });

                options.AddPolicy(CustomPolicies.CanEdit, policy =>
                {
                    policy.RequireAssertion(context =>
                    {
                        if (context.User.IsInRole(CustomRoles.Admin))
                            return true;

                        return context.User.HasClaim(CustomClaimTypes.HasApproved, "True");
                    });
                });

                options.AddPolicy(CustomPolicies.CanCreate, policy =>
                {
                    policy.RequireAssertion(context =>
                    {
                        if (context.User.IsInRole(CustomRoles.Admin))
                            return true;

                        return context.User.HasClaim(CustomClaimTypes.HasApproved, "True");
                    });
                });

                options.AddPolicy(CustomPolicies.CanAddToCollection, policy =>
                {
                    policy.RequireAssertion(context =>
                    {
                        if (context.User.IsInRole(CustomRoles.Admin))
                            return true;

                        return context.User.HasClaim(CustomClaimTypes.HasApproved, "True");
                    });
                });

                options.AddPolicy(CustomPolicies.CanAddFavorite, policy =>
                {
                    policy.RequireAssertion(context =>
                    {
                        if (context.User.IsInRole(CustomRoles.Admin))
                            return true;

                        return context.User.HasClaim(CustomClaimTypes.HasApproved, "True");
                    });
                });

                options.AddPolicy(CustomPolicies.CanDelete, policy =>
                    policy.RequireAssertion(context => context.User.IsInRole(CustomRoles.Admin)));
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Caps-N-Sneakers API v1");
                });
            }

            app.UseCors(builder => builder.AllowAnyOrigin()
                                            .AllowAnyHeader()
                                            .AllowAnyMethod());

            app.UseHttpsRedirection();

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