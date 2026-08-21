using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("TicketStatuses")]
    public class TicketStatus
    {
        [Key]
        [Display(Name = "Status ID")]
        public int StatusId { get; set; }

        [Required(ErrorMessage = "Status name is required.")]
        [StringLength(50)]
        [Display(Name = "Status Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Is Closed State")]
        public int IsClosedState { get; set; } = 0;

        [Display(Name = "Sort Order")]
        public int SortOrder { get; set; } = 0;
    }
}