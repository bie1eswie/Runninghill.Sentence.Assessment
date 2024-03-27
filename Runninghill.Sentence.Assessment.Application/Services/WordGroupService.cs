using AutoMapper;
using Runninghill.Sentence.Assessment.Application.Models;
using Runninghill.Sentence.Assessment.Domain.Interface.Repositories;
using Runninghill.Sentence.Assessment.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Application.Services
{
    public class WordGroupService(IWordGroupRepository _wordGroupRepository, IMapper _mapper) : IWordGroupService
    {
        public async Task<List<WordGroupDTO>> GetWordGroups()
        {
            var result = await _wordGroupRepository.GetAllWordsGroupAsync();
            return _mapper.Map<List<WordGroupDTO>>(result);
        }
    }
}
