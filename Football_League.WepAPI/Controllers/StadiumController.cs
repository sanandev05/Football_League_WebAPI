using Football_League.BLL.Services.Interfaces;
using Football_League.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using static Football_League.BLL.Dtos.Dtos;

namespace Football_League.WepAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StadiumController : ControllerBase
    {
        private readonly IStadiumService _stadiumService;

        public StadiumController(IStadiumService stadiumService)
        {
            _stadiumService = stadiumService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StadiumSaveDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _stadiumService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var stadium = await _stadiumService.GetByIdAsync(id);
            if (stadium == null)
                return NotFound();

            return Ok(stadium);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stadiums = await _stadiumService.GetAllAsync();
            return Ok(stadiums);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StadiumSaveDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _stadiumService.UpdateAsync(id, dto);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _stadiumService.DeleteAsync(id);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
