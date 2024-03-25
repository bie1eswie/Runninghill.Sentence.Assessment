using Runninghill.Sentence.Assessment.Domain.Entities;
using Runninghill.Sentence.Assessment.Domain.Enums;
using Runninghill.Sentence.Assessment.Domain.Interface.Repositories;
using Runninghill.Sentence.Assessment.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Application.Services
{
    public class WordItemService(IWordRepository _wordRepository) : IWordItemService
    {
        public async Task<WordGroup> GetWordItemsAsync(WordType wordType)
        {
            return await _wordRepository.GetWordItemsAsync(wordType);
        }
    }
}
