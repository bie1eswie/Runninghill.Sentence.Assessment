using AutoMapper;
using Runninghill.Sentence.Assessment.Application.Models;
using Runninghill.Sentence.Assessment.Domain.Entities;
using Runninghill.Sentence.Assessment.Domain.Enums;
using Runninghill.Sentence.Assessment.Domain.Interface.Repositories;
using Runninghill.Sentence.Assessment.Domain.Interface.Services;

namespace Runninghill.Sentence.Assessment.Application.Services
{
    public class WordItemService(IWordRepository _wordRepository, IMapper _mapper) : IWordItemService
    {
        public async Task<WordGroupDTO> GetWordItemsAsync(WordType wordType)
        {
            var result = await _wordRepository.GetWordItemsAsync(wordType);
            var items =  _mapper.Map<WordGroupDTO>(result);
            return items;
        }
    }
}
