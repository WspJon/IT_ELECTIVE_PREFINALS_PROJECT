using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("TicketTags")]
    public class TicketTag
    {
        public int TicketId { get; set; }
        public int TagId { get; set; }
        public string? TaggedAt { get; set; }

        [ForeignKey("TicketId")]
        public virtual Ticket? Ticket { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag? Tag { get; set; }
    }
}