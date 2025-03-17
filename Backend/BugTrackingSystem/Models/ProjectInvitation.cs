namespace BugTrackingSystem.Models
{
    public class ProjectInvitation
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string InvitedUserEmail { get; set; } // <--- storing email here
        public RoleType Role { get; set; }
        public bool IsAccepted { get; set; } = false;
    }

}
