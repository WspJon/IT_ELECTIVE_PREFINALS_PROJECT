using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string JobTitle { get; set; } = string.Empty;

        public string HireDate { get; set; } = string.Empty;

        public int IsActive { get; set; } = 1;

        [ForeignKey("DepartmentId")]
        public virtual Department? Department { get; set; }

        public virtual ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
        public virtual ICollection<TicketAssignment> TicketAssignments { get; set; } = new List<TicketAssignment>();
        public virtual ICollection<TicketComment> TicketComments { get; set; } = new List<TicketComment>();
    }
}