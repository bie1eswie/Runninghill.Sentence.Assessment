using Microsoft.Extensions.DependencyInjection;
using Microsoft.Graph;
using Runninghill.Sentence.Assessment.Infrastructure.Data;

namespace Runninghill.Sentence.Assessment.Infrastructure.Extentions
{
    public static class InitialiserExtensions
    {
        public static async Task InitialiseDatabaseAsync(this IServiceProvider service)
        {
            using var scope = service.CreateScope();

            var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

            await initialiser.InitialiseAsync();

            await initialiser.SeedAsync();
        }
    }
}
