using API.Errors;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Runninghill.Sentence.Assessment.Application.Models;
using Runninghill.Sentence.Assessment.Domain.Entities;
using Runninghill.Sentence.Assessment.Domain.Interface.Services;
using Runninghill.Sentence.Assessment.Infrastructure;

namespace Runninghill.Sentence.Assessment.Controllers
{
    public class UserSentenceController(ISentenceService _sentenceService, ILogger<UserSentenceController> _logger) : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(int pageNumber)
        {
            try
            {
                var result = await _sentenceService.GetPaginatedListUserSentence(pageNumber);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(exception: ex,ex.Message);
                return BadRequest(new APIResponse(400, "Problem getting created sentences"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserSentence userSentence)
        {
            try
            {
                var result = await _sentenceService.CreateUserSentence(userSentence);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(exception: ex, ex.Message);
                return BadRequest(new APIResponse(400, "Problem getting created sentences"));
            }
        }
    }
}
