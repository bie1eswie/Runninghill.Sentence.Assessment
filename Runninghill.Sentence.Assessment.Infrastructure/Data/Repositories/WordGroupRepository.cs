using Microsoft.EntityFrameworkCore;
using Runninghill.Sentence.Assessment.Domain.Entities;
using Runninghill.Sentence.Assessment.Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Infrastructure.Data.Repositories
{
    public class WordGroupRepository(RunninghillSentenceAssessmentContext _runninghillSentenceAssessmentContext) : IWordGroupRepository
    {
        public async Task<List<WordGroup>> GetAllWordsGroupAsync()
        {
            return await _runninghillSentenceAssessmentContext.WordGroups.ToListAsync();
        }
    }
}
