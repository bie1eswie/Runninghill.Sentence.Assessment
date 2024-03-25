using API.Errors;
using Microsoft.AspNetCore.Mvc;
using Runninghill.Sentence.Assessment.Domain.Enums;
using Runninghill.Sentence.Assessment.Domain.Interface.Services;
using Runninghill.Sentence.Assessment.Infrastructure;

namespace Runninghill.Sentence.Assessment.Controllers
{
    public class WordController(IWordItemService _wordItemService, ILogger<WordController> _logger) : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(WordType wordType)
        {
            try
            {
                var result = await _wordItemService.GetWordItemsAsync(wordType);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(exception: ex, ex.Message);
                return BadRequest(new APIResponse(400, "Problem getting selected word type's words"));
            }
        }
    }
}
