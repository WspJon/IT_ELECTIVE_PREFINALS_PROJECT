using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("TicketAssignments")]
    public class TicketAssignment
    {
        public int TicketId { get; set; }
        public int EmployeeId { get; set; }

        public int IsPrimary { get; set; } = 0;
        public string? AssignedAt { get; set; }
        public string? UnassignedAt { get; set; }

        [ForeignKey("TicketId")]
        public virtual Ticket? Ticket { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
    }
}