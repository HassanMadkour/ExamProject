using System.Text;
using ExamProject.Application.MappingConfig;
using ExamProject.Domain.Entities;
using ExamProject.Domain.Expections;
using ExamProject.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ExamProject {

    public class Program {

        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(
              Options => {
            Options.Password.RequireNonAlphanumeric = false;
                    }) .AddEntityFrameworkStores<ExamDbContext>().AddDefaultTokenProviders();
            builder.Services.AddDbContext<ExamDbContext>(
                Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("ExamDbConnection"))
                );
            builder.Services.AddTransient<IEmailSender, EmailSender>();
            var jwtSettings = builder.Configuration.GetSection("Jwt");
            builder.Services.AddAuthentication(opt => opt.DefaultAuthenticateScheme = "defSheme")
                .AddJwtBearer("defSheme", op =>
                {
                    op.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,     
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings["Key"]))

                    };
                });
            builder.Services.AddAutoMapper(typeof(AuthenticationMapping) , typeof(AdminMapping) , typeof(StudentMapping));

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.MapOpenApi();
                app.UseSwaggerUI(options => { options.SwaggerEndpoint("/openapi/v1.json", "v1"); });

            }

            app.UseHttpsRedirection();

            app.UseAuthentication(); 
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}