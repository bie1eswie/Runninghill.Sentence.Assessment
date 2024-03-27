using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Runninghill.Sentence.Assessment.Domain.Interface.Repositories;
using Runninghill.Sentence.Assessment.Infrastructure.Common;
using Runninghill.Sentence.Assessment.Infrastructure.Data;
using Runninghill.Sentence.Assessment.Infrastructure.Data.Repositories;

namespace Runninghill.Sentence.Assessment.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IWordRepository, WordRepository>();
            services.AddScoped<IUserSentenceRepository, UserSentenceRepository>();
            services.AddScoped<IWordGroupRepository, WordGroupRepository>();
            //add data context
            string? connectionString = config.GetConnectionString(Constants.DEFAULT_CONNECTION_STRING);
            services.AddDbContext<RunninghillSentenceAssessmentContext>(options =>
             options.UseSqlServer(connectionString)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    .EnableSensitiveDataLogging());

            services.AddScoped<ApplicationDbContextInitialiser>();

            return services;
        }
    }
}
