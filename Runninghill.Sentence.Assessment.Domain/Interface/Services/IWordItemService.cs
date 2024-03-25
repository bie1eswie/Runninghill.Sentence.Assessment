using Runninghill.Sentence.Assessment.Domain.Entities;
using Runninghill.Sentence.Assessment.Domain.Enums;

namespace Runninghill.Sentence.Assessment.Domain.Interface.Services
{
    public interface IWordItemService
    {
        Task<WordGroup> GetWordItemsAsync(WordType wordType);
    }
}
