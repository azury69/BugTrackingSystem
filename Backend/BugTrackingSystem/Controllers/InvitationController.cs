using BugTrackingSystem.Data;
using BugTrackingSystem.Migrations;
using BugTrackingSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTrackingSystem.Controllers
{
   
    [ApiController]
    public class InvitationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public InvitationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
            _context = context;
        }
        // Send Invitation
        [HttpPost("api/sendInvitation")]
        public async Task<IActionResult> SendInvitation([FromBody] ProjectInvitationDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var invitedUser = await _userManager.FindByEmailAsync(model.InvitedUserEmail);
            if (invitedUser == null)
            {
                return NotFound("User not found.");
            }

            // Create the Invitation
            var invitation = new ProjectInvitation
            {
                ProjectId = model.ProjectId,
                InvitedUserEmail = model.InvitedUserEmail,
                Role = model.Role
            };

            _context.Invitatoins.Add(invitation);
            await _context.SaveChangesAsync();

            // Send email or notification (if applicable)
            // Here you can use your logic to send an email to the invited user

            return Ok("Invitation sent.");
        }
        [HttpPost("api/acceptInvitation")]
        public async Task<IActionResult> AcceptInvitation(int invitationId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var invitation = await _context.Invitatoins.FindAsync(invitationId);
            if (invitation == null || invitation.IsAccepted)
            {
                return NotFound("Invitation not found or already accepted.");
            }

            // Find the registered user by email
            var user = await _userManager.FindByEmailAsync(invitation.InvitedUserEmail);
            if (user == null)
            {
                return NotFound("User not found. Please register first.");
            }

            // Add them to ProjectMembers
            var projectMember = new ProjectMember
            {
                ProjectId = invitation.ProjectId,
                UserId = user.Id, 
                Role = invitation.Role
            };

            _context.ProjectMembers.Add(projectMember);
            invitation.IsAccepted = true;

            await _context.SaveChangesAsync();

            return Ok("Invitation accepted and role assigned.");
        }
        [HttpGet("api/getPendingInvitations")]
        public async Task<IActionResult> GetPendingInvitations([FromQuery] string userId)
        {
            var invitations = await _context.Invitatoins
                .Where(i => i.InvitedUserEmail == userId && !i.IsAccepted)
                .ToListAsync();

            var invitationDtos = invitations.Select(i => new {
                i.Id,
                i.ProjectId,
                i.Role
            }).ToList();

            return Ok(invitationDtos);
        }

    }
}
