namespace BugTrackingSystem.Models
{
    public class Scrum
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public List<Story> Stories { get; set; } = new List<Story>();
    }
}
