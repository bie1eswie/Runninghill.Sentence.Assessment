using Runninghill.Sentence.Assessment.Domain.Entities;
using Runninghill.Sentence.Assessment.Domain.Models;

namespace Runninghill.Sentence.Assessment.Domain.Interface.Repositories
{
    public interface IUserSentenceRepository
    {
        Task<bool> CreateUserSentence(UserSentence userSentence);
        Task<PaginatedList<UserSentence>> GetPaginatedListUserSentence(int pageNumber, int pageSize);
    }
}
