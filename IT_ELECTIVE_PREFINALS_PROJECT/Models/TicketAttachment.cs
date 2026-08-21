using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("TicketAttachments")]
    public class TicketAttachment
    {
        [Key]
        public int AttachmentId { get; set; }

        public int TicketId { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; } = string.Empty;

        [StringLength(255)]
        public string? FilePath { get; set; }

        public int FileSizeBytes { get; set; }

        [StringLength(100)]
        public string? ContentType { get; set; }

        public string? UploadedAt { get; set; }

        [ForeignKey("TicketId")]
        public virtual Ticket? Ticket { get; set; }
    }
}