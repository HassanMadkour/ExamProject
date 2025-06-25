using ExamProject.Domain.Entities;
using ExamProject.Infrastructure.Data;
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
                Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("ExamDbConnection"))
                );

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}