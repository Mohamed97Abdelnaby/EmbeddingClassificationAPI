using EmbeddingClassificationAPI.Models;
using EmbeddingClassificationAPI.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmbeddingClassificationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly CardService _cardService;

        public CardController(CardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost("find_similar_card")]
        public async Task<IActionResult> FindSimilarCard([FromBody] CardInput cardInput)
        {
            try
            {
                var result = await _cardService.FindMostSimilarCardAsync(cardInput.SampleText);
                return Ok(new { most_similar_card = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("add_new_card")]
        public async Task<IActionResult> AddNewCard([FromForm] string cardName, [FromForm] string sampleText)
        {
            try
            {
                await _cardService.AddNewCardAsync(cardName, sampleText);
                return Ok(new { message = "New card added successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
