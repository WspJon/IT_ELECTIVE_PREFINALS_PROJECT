using System.ComponentModel.DataAnnotations;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }

        public int TeamId { get; set; }
        public virtual Team? Team { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }

        public string? RoleInTeam { get; set; }
    }
}