namespace BugTrackingSystem.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedById { get; set; }
        public string CreatedBy { get; set; } 
        public List<ProjectMember> Members { get; set; } = new List<ProjectMember>();
    }
}
