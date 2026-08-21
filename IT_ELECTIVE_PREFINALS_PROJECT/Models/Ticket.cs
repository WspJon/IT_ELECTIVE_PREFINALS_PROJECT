using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int CustomerId { get; set; }
        public int CategoryId { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }

        public string? CreatedAt { get; set; }
        public string? ResolvedAt { get; set; }

        // Navigation Properties
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