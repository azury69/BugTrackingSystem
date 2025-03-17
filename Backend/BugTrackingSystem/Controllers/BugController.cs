using BugTrackingSystem.Data;
using BugTrackingSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTrackingSystem.Controllers
{
    [ApiController]
    [Route("api/bugs")] // Defines base route for the controller
    public class BugController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BugController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create a new bug
        [HttpPost]
        public async Task<IActionResult> CreateBug([FromBody] CreateBugDto dto)
        {
            if (dto == null || dto.StoryId <= 0 || string.IsNullOrEmpty(dto.Title) || string.IsNullOrEmpty(dto.Description))
            {
                return BadRequest("All fields are required.");
            }

            var story = await _context.Stories.FindAsync(dto.StoryId);
            if (story == null)
            {
                return NotFound("Story not found.");
            }

            var bug = new Bug
            {
                Title = dto.Title,
                Description = dto.Description,
                Status = dto.Status ?? "Open",
                StoryId = dto.StoryId
            };

            try
            {
                _context.Bugs.Add(bug);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetBugById), new { id = bug.Id }, bug);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Get bug by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBugById(int id)
        {
            var bug = await _context.Bugs
                .Include(b => b.Story)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (bug == null)
            {
                return NotFound();
            }

            return Ok(bug);
        }

        // Get bugs by story id
        [HttpGet("~/api/stories/{storyId}/bugs")] // RESTful path
        public async Task<IActionResult> GetBugsByStory(int storyId)
        {
            var story = await _context.Stories.FindAsync(storyId);
            if (story == null)
            {
                return NotFound("Story not found.");
            }

            var bugs = await _context.Bugs
                .Where(b => b.StoryId == storyId)
                .ToListAsync();

            return Ok(bugs);
        }
    }
}
