using BugTrackingSystem.Data;
using BugTrackingSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackingSystem.Controllers
{
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet("api/getallprojects")]
        public IActionResult GetAllProjects()
        {
            var currentUser = _userManager.GetUserAsync(User).Result;  // Get the current user
            if (currentUser == null)
            {
                return Unauthorized("You must be logged in to view projects.");
            }

            // Fetch projects based on the current user's involvement (e.g., working on or watching projects)
            var projects = _context.Projects
                .Where(p => p.CreatedById == currentUser.Id)  // Filter by the current user's ID
                .ToList();

            return Ok(projects);
        }
        [HttpPost("api/project")]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectDto createProjectDto)
        {
            if (createProjectDto == null || string.IsNullOrEmpty(createProjectDto.Name) || string.IsNullOrEmpty(createProjectDto.Description))
            {
                return BadRequest("Project name and description are required.");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Unauthorized("You must be logged in to create a project.");
            }

            var project = new Project
            {
                Name = createProjectDto.Name,
                Description = createProjectDto.Description,
                CreatedById = currentUser.Id,
                CreatedBy = currentUser.FullName
            };

            try
            {
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(CreateProject), new { id = project.Id }, project);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        } }}



  
