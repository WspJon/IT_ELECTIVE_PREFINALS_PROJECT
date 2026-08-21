using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("TicketCategories")]
    public class TicketCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }

        public int? ParentCategoryId { get; set; }
        public int IsActive { get; set; } = 1;

        [ForeignKey("ParentCategoryId")]
        public virtual TicketCategory? ParentCategory { get; set; }

        public virtual ICollection<TicketCategory> SubCategories { get; set; } = new List<TicketCategory>();
    }
}