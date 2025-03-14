using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BugTrackingSystem.Models;

namespace BugTrackingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Scrum> Scrums { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Modify delete behavior for ProjectMembers (disable cascade delete)
            modelBuilder.Entity<ProjectMember>()
                .HasOne(pm => pm.User)
                .WithMany(u => u.ProjectMemberships)
                .HasForeignKey(pm => pm.UserId)
                .OnDelete(DeleteBehavior.Restrict); // No cascading delete for ProjectMember -> User

            modelBuilder.Entity<ProjectMember>()
                .HasOne(pm => pm.Project)
                .WithMany(p => p.Members)
                .HasForeignKey(pm => pm.ProjectId)
                .OnDelete(DeleteBehavior.Restrict); // No cascading delete for ProjectMember -> Project

            // Similarly adjust any other relationships as needed (e.g., Story -> AssignedTo)
            modelBuilder.Entity<Story>()
                .HasOne(s => s.AssignedTo)
                .WithMany(u => u.AssignedStories)
                .HasForeignKey(s => s.AssignedToId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascading delete for Story -> AssignedTo (User)
        }
    }
}
