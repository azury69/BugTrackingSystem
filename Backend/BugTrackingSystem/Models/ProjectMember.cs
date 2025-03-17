namespace BugTrackingSystem.Models
{
    public class ProjectMember
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string UserId { get; set; }
        public RoleType Role { get; set; } // E.g., Product Owner, Developer, QA
    }
}
