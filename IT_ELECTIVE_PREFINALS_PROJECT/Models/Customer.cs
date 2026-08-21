using IT_ELECTIVE_PREFINALS_PROJECT.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WspJon.IT_ELECTIVE_PREFINALS_PROJECT.Models
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

        // Navigation Property linking Customer to Tickets
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}