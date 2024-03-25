using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Runninghill.Sentence.Assessment.Infrastructure.SeedData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Infrastructure.Data
{
    public class ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> _logger, RunninghillSentenceAssessmentContext _runninghillSentenceAssessmentContext)
    {
        public async Task InitialiseAsync()
        {
            try
            {
                await _runninghillSentenceAssessmentContext.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            //WordGroups
            if (!_runninghillSentenceAssessmentContext.WordGroups.Any())
            {
                var wordGroups = WordGroupData.ListWordGroup;
               await _runninghillSentenceAssessmentContext.AddRangeAsync(wordGroups);
                await _runninghillSentenceAssessmentContext.SaveChangesAsync();
            }

            //
            if (!_runninghillSentenceAssessmentContext.WordItems.Any())
            {
                var wordItems = WordItemData.ListWordItem;
                await _runninghillSentenceAssessmentContext.AddRangeAsync(wordItems);
                await _runninghillSentenceAssessmentContext.SaveChangesAsync();
            }
        }
    }
}
