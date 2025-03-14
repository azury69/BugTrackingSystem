using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BugTrackingSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        public List<Project> CreatedProjects { get; set; } = new List<Project>();

        public List<ProjectMember> ProjectMemberships { get; set; } = new List<ProjectMember>();

        public List<Story> AssignedStories { get; set; } = new List<Story>();
    }
}
