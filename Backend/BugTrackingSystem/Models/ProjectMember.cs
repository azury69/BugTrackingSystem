namespace BugTrackingSystem.Models
{
    public class ProjectMember
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }  // Link to ApplicationUser
        public int ProjectId { get; set; }
        public Project Project { get; set; } // Link to Project
        public RoleType Role { get; set; }
    }
}
