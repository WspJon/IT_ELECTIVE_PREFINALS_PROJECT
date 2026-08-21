using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("Teams")]
    public class Team
    {
        [Key]
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department? Department { get; set; }

        public virtual ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
    }
}