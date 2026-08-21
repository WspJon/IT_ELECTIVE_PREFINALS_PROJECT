using IT_ELECTIVE_PREFINALS_PROJECT.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Data
{
    public class HelpDeskContext : DbContext
    {
        public HelpDeskContext(DbContextOptions<HelpDeskContext> options)
            : base(options)
        {
        }

        // Existing DbSets (from Member 1)
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<TeamMember> TeamMembers { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;

        // Member 2 DbSets
        public DbSet<TicketCategory> TicketCategories { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<TicketAssignment> TicketAssignments { get; set; } = null!;
        public DbSet<TicketComment> TicketComments { get; set; } = null!;
        public DbSet<TicketTag> TicketTags { get; set; } = null!;
        public DbSet<TicketAttachment> TicketAttachments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite Key Mappings

            // 1. TeamMember composite key (team_id, employee_id)
            modelBuilder.Entity<TeamMember>()
                .HasKey(tm => new { tm.TeamId, tm.EmployeeId });

            // 2. TicketAssignment composite key (ticket_id, employee_id)
            modelBuilder.Entity<TicketAssignment>()
                .HasKey(ta => new { ta.TicketId, ta.EmployeeId });

            // 3. TicketTag composite key (ticket_id, tag_id)
            modelBuilder.Entity<TicketTag>()
                .HasKey(tt => new { tt.TicketId, tt.TagId });

            // Self-referencing relationship for TicketCategory
            modelBuilder.Entity<TicketCategory>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}