using Football_League.BLL.Dtos;
using Football_League.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Football_League.BLL.Dtos.Dtos;

namespace Football_League.WepAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var models = await _teamService.GetByIdAsync(id);
            if(models == null)
            {
                return NotFound();
            }
            return View(models);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TeamSaveDto courseDto)
        {
            if (courseDto == null)
            {
                return BadRequest("Course data is null");
            }
            var addedCourse = await _teamService.CreateAsync(courseDto);
            return CreatedAtAction(nameof(GetById), new { id = addedCourse.Id }, addedCourse);
        }

    }
}
