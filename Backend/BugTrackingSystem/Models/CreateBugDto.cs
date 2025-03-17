namespace BugTrackingSystem.Models
{
    public class CreateBugDto
    {
        public string Title { get; set; }          // Bug title
        public string Description { get; set; }   // Detailed bug description
        public string Status { get; set; }        // Status (e.g., "Open", "In Progress", "Resolved")
        public int StoryId { get; set; }          // The Story to which the bug belongs
        //public List<int> AttachmentIds { get; set; } = new List<int>(); // Attachments (if any)
    }
}
