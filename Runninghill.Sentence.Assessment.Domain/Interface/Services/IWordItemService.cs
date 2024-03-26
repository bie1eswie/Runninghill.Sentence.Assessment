using Runninghill.Sentence.Assessment.Application.Models;
using Runninghill.Sentence.Assessment.Domain.Entities;
using Runninghill.Sentence.Assessment.Domain.Enums;

namespace Runninghill.Sentence.Assessment.Domain.Interface.Services
{
    public interface IWordItemService
    {
        Task<WordGroupDTO> GetWordItemsAsync(WordType wordType);
    }
}
