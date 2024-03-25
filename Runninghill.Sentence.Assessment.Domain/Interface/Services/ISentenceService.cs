using Runninghill.Sentence.Assessment.Domain.Entities;
using Runninghill.Sentence.Assessment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Domain.Interface.Services
{
    public interface ISentenceService
    {
        Task<PaginatedList<UserSentence>> GetPaginatedListUserSentence(int pageNumber);
        Task<bool> CreateUserSentence(UserSentence userSentence);
    }
}
