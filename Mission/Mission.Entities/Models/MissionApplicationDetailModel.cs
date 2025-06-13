using System.ComponentModel.DataAnnotations;

namespace Mission.Entities.Models
{
    public class MissionApplicationDetailModel
    {
        public int ApplicationId { get; set; }

        [Required]
        public string MissionTitle { get; set; } = string.Empty;

        [Required]
        public string MissionTheme { get; set; } = string.Empty;

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public DateTime ApplicationDate { get; set; }

        [Required]
        public string Status { get; set; } = string.Empty;

        // Additional properties that might be useful
        public int MissionId { get; set; }
        public int UserId { get; set; }
        public string? AppliedDate { get; set; }
        public string? ApprovalDate { get; set; }
        public string? Remarks { get; set; }

        // User details if needed
        public string? UserEmail { get; set; }
        public string? UserPhone { get; set; }

        // Mission details if needed
        public string? MissionDescription { get; set; }
        public DateTime? MissionStartDate { get; set; }
        public DateTime? MissionEndDate { get; set; }
        public string? MissionLocation { get; set; }
    }
}