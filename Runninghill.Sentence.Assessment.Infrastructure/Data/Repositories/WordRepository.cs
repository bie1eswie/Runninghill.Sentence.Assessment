using Microsoft.EntityFrameworkCore;
using Runninghill.Sentence.Assessment.Domain.Entities;
using Runninghill.Sentence.Assessment.Domain.Enums;
using Runninghill.Sentence.Assessment.Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Infrastructure.Data.Repositories
{
    public class WordRepository(RunninghillSentenceAssessmentContext _runninghillSentenceAssessmentContext) : IWordRepository
    {
        public async Task<WordGroup> GetWordItemsAsync(WordType wordType)
        {
            var items = await _runninghillSentenceAssessmentContext.WordGroups
                            .Where(x => x.WordType == wordType)
                            .Include(x => x.Items)
                            .AsNoTracking()
                            .FirstOrDefaultAsync();
            return items!;
        }
    }
}
