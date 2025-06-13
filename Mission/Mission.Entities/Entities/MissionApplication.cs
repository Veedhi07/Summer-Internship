using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission.Entities
{
    [Table("MissionApplication")] // Specify the table name
    public class MissionApplication : BaseEntity // Assuming BaseEntity defines common properties
    {
        [Key]
        public int Id { get; set; }

        public int MissionId { get; set; }

        public int UserId { get; set; }

        public DateTime AppliedDate { get; set; }

        public bool Status { get; set; }

        public int Seats { get; set; }

        [ForeignKey(nameof(MissionId))]
        public virtual Missions Mission { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } = null!;
    }
}
