using Football_League.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Football_League.BLL.Dtos.Dtos;

namespace Football_League.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var matches = await _matchService.GetAllAsync();
            return Ok(matches);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var match = await _matchService.GetByIdAsync(id);
            if (match == null)
                return NotFound();

            return Ok(match);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MatchSaveDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdMatch = await _matchService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdMatch.Id }, createdMatch);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MatchSaveDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _matchService.UpdateAsync(id, dto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _matchService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}
