using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace BugTrackingSystem.Models
{
    public class ProjectInvitationDto
    {
        public int ProjectId { get; set; }
        public string InvitedUserEmail { get; set; }

        public string Role { get; set; }
    }
}
