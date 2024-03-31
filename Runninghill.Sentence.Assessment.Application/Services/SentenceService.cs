using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Options;
using PaySpace.Calculation.Assessment.Domain.Configuration;
using Runninghill.Sentence.Assessment.Domain.Entities;
using Runninghill.Sentence.Assessment.Domain.Exceptions;
using Runninghill.Sentence.Assessment.Domain.Interface.Repositories;
using Runninghill.Sentence.Assessment.Domain.Interface.Services;
using Runninghill.Sentence.Assessment.Domain.Models;
namespace Runninghill.Sentence.Assessment.Application.Services
{
    public class SentenceService(IUserSentenceRepository _sentenceRepository, IOptions<ConfigurationOptions> options,IMapper _mapper, IValidator<UserSentenceDTO> validator) : ISentenceService
    {
        public async Task<bool> CreateUserSentence(UserSentenceDTO userSentence)
        {
            var result = validator.Validate(userSentence);
            if (!result.IsValid)
            {
                throw new InvalidUserSentenceException("There was an error created your sentence");
            }
            var sentence = _mapper.Map<UserSentence>(userSentence);
            return await _sentenceRepository.CreateUserSentence(sentence);
        }

        public async Task<PaginatedList<UserSentence>> GetPaginatedListUserSentence(int pageNumber)
        {
           return await _sentenceRepository.GetPaginatedListUserSentence(pageNumber,options.Value.PageSize);
        }
    }
}
