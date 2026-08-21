using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("TeamMembers")]
    public class TeamMember
    {
        public int TeamId { get; set; }
        public int EmployeeId { get; set; }
        public string JoinedAt { get; set; } = string.Empty;

        [ForeignKey("TeamId")]
        public virtual Team? Team { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
    }
}