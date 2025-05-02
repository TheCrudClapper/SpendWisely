using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Entities.DatabaseContexts;
using Entities.Models.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Services.ServiceContracts;
using Services.Services;

namespace SpendWiselyRestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SpendWisely"),
                item => item.MigrationsAssembly("Entities")));



            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();

            var jwtKey = builder.Configuration["Jwt:Key"] ?? "SUPER_SECRET_KEY_ONLY_YOUR_MAMA_KNOW_THAT";
            var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? "SpendWiselyAPI";
            var jwtAudience = builder.Configuration["Jwt:Audience"] ?? "SpendWiselyApp";

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtIssuer,
                    ValidAudience = jwtAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey!))
                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser().Build();
            });

            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
