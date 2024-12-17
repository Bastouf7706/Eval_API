using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using API.ApiDbContexts;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class achievement.Controller : ControllerBase
    {
        private readonly ApiDbContext _context;

    public achievementController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAchievement()
    {
        var achievement = await _context.Achievement.ToListAsync();
        return Ok(achievement);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAchievement (int id)
        {
        var achievement = await _context.Achievement.FindAsync(id);

        if (achievement == null)
        {
            return NotFound("Succes non trouvé");
        }

        return Ok(achievement);
        }
    [HttpPost]
    public async Task<IActionResult> CreateAchievement([FromBody] achievement achievement)
    {
        if (achievement == null || string.IsNullOrEmpty(Achievement.Name))
        {
            return BadRequest("Les informations du succes invalides");
        }

        _context.Achievements.Add(achievement);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAchievement), new { id = achievement.Id }, achievement);
    }
    [HttpPut("Id")]
    public async Task<IActionResult> UpdateAchievement(int id, [FromBody] Achievement updatedAchievement)
    {
        var achievement = await _context.Achievement.FindAsync(id);

        if (achievement = null)
        {
            return NotFound("Succes non trouver");
        }
        achievement.Name = updatedAchievement.Name ?? achievement.Name;
        achievement.Description = updatedAchievement.Description ?? achievement.Description;

        _context.Achievements.Update(achievement);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAchievement(int id)
    {
        var achievement = await _context.Achievements.FindAsync(id);

        if (achievement == null)
        {
            return NotFound("Succès non trouvé.");
        }

        _context.Achievements.Remove(achievement);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}