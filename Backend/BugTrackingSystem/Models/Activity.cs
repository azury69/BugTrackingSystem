namespace BugTrackingSystem.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public int StoryId { get; set; }
        public Story Story { get; set; }
    }
}
