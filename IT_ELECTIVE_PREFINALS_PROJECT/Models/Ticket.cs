using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public int CategoryId { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }

        [Required]
        public string Subject { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public string CreatedAt { get; set; } = string.Empty;
        public string UpdatedAt { get; set; } = string.Empty;
        public string? DueAt { get; set; }
        public string? ResolvedAt { get; set; }
        public string? ClosedAt { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        [ForeignKey("CategoryId")]
        public virtual TicketCategory? Category { get; set; }

        [ForeignKey("PriorityId")]
        public virtual TicketPriority? Priority { get; set; }

        [ForeignKey("StatusId")]
        public virtual TicketStatus? Status { get; set; }

        public virtual ICollection<TicketAssignment> TicketAssignments { get; set; } = new List<TicketAssignment>();
        public virtual ICollection<TicketComment> TicketComments { get; set; } = new List<TicketComment>();
        public virtual ICollection<TicketTag> TicketTags { get; set; } = new List<TicketTag>();
        public virtual ICollection<TicketAttachment> TicketAttachments { get; set; } = new List<TicketAttachment>();
    }
}