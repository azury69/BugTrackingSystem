namespace BugTrackingSystem.Models
{
    public class ProjectInvitationDto
    {
        public int ProjectId { get; set; }
        public string InvitedUserEmail { get; set; }
        public RoleType Role { get; set; }
    }
}
