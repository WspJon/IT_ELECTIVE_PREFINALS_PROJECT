using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("Teams")]
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }

        public int DepartmentId { get; set; }

        public int IsActive { get; set; } = 1;

        // Navigation Properties
        [ForeignKey("DepartmentId")]
        public virtual Department? Department { get; set; }

        public virtual ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
    }
}