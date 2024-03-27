using Microsoft.EntityFrameworkCore;
using Runninghill.Sentence.Assessment.Infrastructure.Common;
using Runninghill.Sentence.Assessment.Infrastructure.Data;

namespace Runninghill.Sentence.Assessment.Infrastructure
{
    public static class DependencyInjection
    {
        public static void ApplyDatabaseMigrations(this WebApplication app, IConfiguration configuration)
        {
            var logger = app.Logger;
            try
            {
                var applyMigrations = configuration.GetValue(Constants.APPLY_MIGRATIONS, false);

                logger.LogInformation($"Apply Migrations Config set to: {applyMigrations}");

                if (applyMigrations)
                {
                    using var serviceScope = app.Services
                        .GetRequiredService<IServiceScopeFactory>()
                        .CreateScope();
                    ApplyMigration<RunninghillSentenceAssessmentContext>(serviceScope, logger);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
            }
        }
        private static void ApplyMigration<T>(IServiceScope serviceScope, ILogger logger) where T : DbContext
        {
            try
            {
                using var context = serviceScope.ServiceProvider.GetService<T>();
                var pendingMigrations = context?.Database.GetPendingMigrations().ToList();

                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    logger.LogInformation($"Applying {typeof(T).Name} Migrations");

                    foreach (var migration in pendingMigrations)
                    {
                        logger.LogInformation($"{migration} must still be applied!");
                    }

                    context?.Database.Migrate();
                }
                else
                {
                    logger.LogInformation($"No Migrations to apply {typeof(T).Name}");
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Applying migrations threw an exception: {Message}, \n Inner Exception : {InnerException}, \n StackTrace :{StackTrace}", ex.Message, ex.InnerException, ex.StackTrace);
            }

            logger.LogInformation($"Migrations {typeof(T).Name} Completed");
        }

        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                var allowedHosts = configuration["AllowedHosts"]!;
                string[] methods = { "GET", "POST", "PUT", "DELETE", "PATCH", "OPTIONS" };
                options.AddPolicy("AllowFrontend", builder => builder.WithOrigins(allowedHosts).AllowAnyHeader().WithMethods(methods));
            });

            return services;
        }
    }
}
