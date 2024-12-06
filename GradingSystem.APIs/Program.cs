using GradingSystem.Core.Repositories.Contact;
using GradingSystem.Repository;
using GradingSystem.Repository.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace GradingSystem.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services
            // Add services to the container.

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<GradingSystemDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // builder.Services.AddScoped<IGenericRepository<Admin>, GenericRepository<Admin>>();
            // We Have 20 Entities In Our Project. It's Not Preferred/Right To Register 20 Entities(20 Lines).
            // Thus, I Use Generic Of AddScoped
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            #endregion

            var app = builder.Build();

            #region Update Database Automatically
            var scope = app.Services.CreateScope();

            var services = scope.ServiceProvider;

            var _dbContext = services.GetRequiredService<GradingSystemDbContext>(); // Ask CLR For Creating An Object DbContext Explicitly

            // To Handle Errors In Console Screen In An Organized Manner => Ask CLR For Object Of Class That Implement ILoggerFactory Interface To Handle This
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await _dbContext.Database.MigrateAsync(); // Update Database Automatically
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An Error Has Been Occurred During Applying The Migration");
            } 
            #endregion

            #region Configure Kestrel Middlewares
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            #endregion

            app.Run();
        }
    }
}
