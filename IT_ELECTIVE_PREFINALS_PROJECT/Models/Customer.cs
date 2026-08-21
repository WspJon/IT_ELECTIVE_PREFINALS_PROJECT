using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Company { get; set; }

        public int IsActive { get; set; } = 1;

        // Navigation Property (Task M3.1)
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}