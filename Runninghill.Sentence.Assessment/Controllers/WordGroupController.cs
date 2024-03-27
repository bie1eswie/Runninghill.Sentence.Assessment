using API.Errors;
using Microsoft.AspNetCore.Mvc;
using Runninghill.Sentence.Assessment.Domain.Interface.Services;
using Runninghill.Sentence.Assessment.Infrastructure;

namespace Runninghill.Sentence.Assessment.Controllers
{
    public class WordGroupController(IWordGroupService _wordGroupService, ILogger<WordGroupController> _logger) : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _wordGroupService.GetWordGroups();
                return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.LogError(exception: ex, ex.Message);
                return BadRequest(new APIResponse(400, "Problem getting word types"));
            }
        }
    }
}
