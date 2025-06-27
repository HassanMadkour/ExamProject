using ExamProject.Domain.Entities;
using ExamProject.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExamProject {

    public class Program {

        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddAutoMapper(typeof(AdminMapping));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(
                Options => {
                    Options.Password.RequireNonAlphanumeric = true;
                    Options.Password.RequireLowercase = true;
                    Options.Password.RequireUppercase = true;
                    Options.Password.RequireDigit = true;
                }
              Options => {
               Options.Password.RequireNonAlphanumeric = false;
              }
                )
                .AddEntityFrameworkStores<ExamDbContext>().AddDefaultTokenProviders();
            builder.Services.AddDbContext<ExamDbContext>(
                Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("ExamDbConnection"))
                );

            builder.Services.AddAutoMapper(typeof(MappingConfig));

            // Add services to the container.
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IExamService,ExamService>();

            builder.Services.AddControllers();
            builder.Services.AddCors(
                (op) => op.AddPolicy("AllowAll", (policy) => {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                })
                );
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.MapOpenApi();
                app.UseSwaggerUI((op) => op.SwaggerEndpoint("/openapi/v1.json", "v1"));
                app.UseSwaggerUI(op => op.SwaggerEndpoint("/openapi/v1.json", "V1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowAll");

            app.MapControllers();

            app.Run();
        }
    }
}