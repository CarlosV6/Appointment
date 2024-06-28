using UserManagement;
using UserManagement.Configuration;

namespace UserManagement
{
    internal partial class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Settings to read from appsettings.Development.json
            IConfiguration configurations = (IConfiguration)builder.Configuration
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile(@$"appsettings.{environment}.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables();

            // Add services to the container.
            builder.Services.AddInfrastructure(configurations);
            builder.Services.AddScoped<UserManagementProcess>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            Task.Run(() =>
            {
                using var scope = app.Services.CreateScope();
                var Process = scope.ServiceProvider.GetRequiredService<UserManagementProcess>();
                Process.StartProcess();
            });

            app.Run();
        }
    }

}
