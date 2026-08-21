using Microsoft.EntityFrameworkCore;
using IT_ELECTIVE_PREFINALS_PROJECT.Models;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Data
{
    public class HelpDeskContext : DbContext
    {
        public HelpDeskContext(DbContextOptions<HelpDeskContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<TicketPriority> TicketPriorities { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketAssignment> TicketAssignments { get; set; }
        public DbSet<TicketComment> TicketComments { get; set; }
        public DbSet<TicketTag> TicketTags { get; set; }
        public DbSet<TicketAttachment> TicketAttachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite Primary Keys
            modelBuilder.Entity<TeamMember>()
                .HasKey(tm => new { tm.TeamId, tm.EmployeeId });

            modelBuilder.Entity<TicketAssignment>()
                .HasKey(ta => new { ta.TicketId, ta.EmployeeId });

            modelBuilder.Entity<TicketTag>()
                .HasKey(tt => new { tt.TicketId, tt.TagId });

            // Unique Constraints / Indexes
            modelBuilder.Entity<Department>()
                .HasIndex(d => d.Name)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Tag>()
                .HasIndex(t => t.Name)
                .IsUnique();
        }
    }
}