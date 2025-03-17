using System.Diagnostics;
using System.Net.Mail;

namespace BugTrackingSystem.Models
{
    public class Story
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Additional properties from DTO
        public string? AssignedToId { get; set; }    // The user ID to whom the story is assigned
        public int Points { get; set; }             // Estimated points for the story

        // Foreign Key to Sprint (nullable because not all stories are assigned to a sprint)
        public int? SprintId { get; set; }
        public Sprint? Sprint { get; set; }

        // Navigation properties for related entities
        public List<Attachment>? Attachments { get; set; } = new List<Attachment>();
        public List<Comment>? Comments { get; set; } = new List<Comment>();
        public List<Activity>? Activities { get; set; } = new List<Activity>();
    }
}
