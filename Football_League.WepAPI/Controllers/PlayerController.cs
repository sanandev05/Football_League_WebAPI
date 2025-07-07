using Football_League.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Football_League.BLL.Dtos.Dtos;

namespace Football_League.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var players = await _playerService.GetAllAsync();
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var player = await _playerService.GetByIdAsync(id);
            if (player == null)
                return NotFound();

            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PlayerSaveDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _playerService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PlayerSaveDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _playerService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _playerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
