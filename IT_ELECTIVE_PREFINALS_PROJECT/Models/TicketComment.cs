using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("TicketComments")]
    public class TicketComment
    {
        [Key]
        public int Id { get; set; }

        public int TicketId { get; set; }
        public int? EmployeeId { get; set; }

        [Required]
        public string Comment { get; set; } = string.Empty;

        public string CreatedAt { get; set; } = string.Empty;
        public int IsInternal { get; set; } = 0;

        [ForeignKey("TicketId")]
        public virtual Ticket? Ticket { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
    }
}