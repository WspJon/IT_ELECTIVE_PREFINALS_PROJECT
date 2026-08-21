using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("TicketPriorities")]
    public class TicketPriority
    {
        [Key]
        [Display(Name = "Priority ID")]
        public int PriorityId { get; set; }

        [Required(ErrorMessage = "Priority name is required.")]
        [StringLength(50)]
        [Display(Name = "Priority Level Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Priority Level")]
        public int Level { get; set; } = 1;
    }
}