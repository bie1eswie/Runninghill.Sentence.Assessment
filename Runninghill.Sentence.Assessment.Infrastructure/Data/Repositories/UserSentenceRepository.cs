using Runninghill.Sentence.Assessment.Application.Common.Mappings;
using Runninghill.Sentence.Assessment.Domain.Entities;
using Runninghill.Sentence.Assessment.Domain.Interface.Repositories;
using Runninghill.Sentence.Assessment.Domain.Models;

namespace Runninghill.Sentence.Assessment.Infrastructure.Data.Repositories
{
    public class UserSentenceRepository(RunninghillSentenceAssessmentContext _runninghillSentenceAssessmentContext) : IUserSentenceRepository
    {
        public async Task<bool> CreateUserSentence(UserSentence userSentence)
        {
            _runninghillSentenceAssessmentContext.Sentences.Add(userSentence);
            return await _runninghillSentenceAssessmentContext.SaveChangesAsync() > 0;
        }

        public async Task<PaginatedList<UserSentence>> GetPaginatedListUserSentence(int pageNumber,int pageSize)
        {
            return await _runninghillSentenceAssessmentContext.Sentences
                                                        .AsQueryable()
                                                        .PaginatedListAsync(pageNumber, pageSize);
        }
    }
}
