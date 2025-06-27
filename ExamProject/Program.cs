using ExamProject.Application.Interfaces.IServices;
using ExamProject.Application.Interfaces.IUnitOfWorks;
using ExamProject.Application.MappingConfig;
using ExamProject.Application.Services;
using ExamProject.Domain.Entities;
using ExamProject.Infrastructure.Data;
using ExamProject.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExamProject {

    public class Program {

        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(
              Options => {
               Options.Password.RequireNonAlphanumeric = false;
              }
                )
                .AddEntityFrameworkStores<ExamDbContext>().AddDefaultTokenProviders();
            builder.Services.AddDbContext<ExamDbContext>(
                Options => Options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("ExamDbConnection"))
                );

            builder.Services.AddAutoMapper(typeof(MappingConfig));

            // Add services to the container.
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IExamService,ExamService>();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.MapOpenApi();
                app.UseSwaggerUI(op => op.SwaggerEndpoint("/openapi/v1.json", "V1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}