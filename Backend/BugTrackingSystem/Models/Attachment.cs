namespace BugTrackingSystem.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        public int StoryId { get; set; }
        public Story Story { get; set; }
    }
}
