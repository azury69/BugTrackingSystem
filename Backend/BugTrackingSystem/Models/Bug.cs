namespace BugTrackingSystem.Models
{
    public class Bug
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // e.g., New, In Progress, Resolved
        public int StoryId { get; set; }
        public Story Story { get; set; }
    }

}
