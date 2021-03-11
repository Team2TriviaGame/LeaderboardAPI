using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;

namespace Trivia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly Repository _repo;

        public GameController(Repository repo)
        {
            _repo = repo;
        }

        [HttpGet("scores")]
        public async Task<IActionResult> GetHighScores()
        {
            return Ok(await _repo.GetScoresAsync());
        }

        [HttpGet("scores/{top}")]
        public async Task<IActionResult> GetHighScores(int top)
        {
            return Ok(await _repo.GetScoresAsync(top));
        }

        [HttpPost("score")]
        public async Task<IActionResult> PostScore([FromBody] Score score)
        {
            await _repo.AddScore(score);
            return Ok("Score added successfully");
        }

        
    }
}
