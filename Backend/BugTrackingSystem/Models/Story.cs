namespace BugTrackingSystem.Models
{
    public class Story
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ScrumId { get; set; }
        public Scrum Scrum { get; set; }
        public string AssignedToId { get; set; }
        public ApplicationUser AssignedTo { get; set; }
        public int Points { get; set; }
        public List<string> Attachments { get; set; } = new List<string>();
    }
}
