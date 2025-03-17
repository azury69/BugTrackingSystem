namespace BugTrackingSystem.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; } // The user who posted the comment
        public ApplicationUser User { get; set; }
        public int StoryId { get; set; }
        public Story Story { get; set; }
    }
}
