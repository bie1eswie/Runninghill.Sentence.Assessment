using Runninghill.Sentence.Assessment.Domain.Entities;
using Runninghill.Sentence.Assessment.Domain.Enums;

namespace Runninghill.Sentence.Assessment.Domain.Interface.Repositories
{
    public interface IWordRepository
    {
        public Task<WordGroup> GetWordItemsAsync(WordType wordType);
    }
}
