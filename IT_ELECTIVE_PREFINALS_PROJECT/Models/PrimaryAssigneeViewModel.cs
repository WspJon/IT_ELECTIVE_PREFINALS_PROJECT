namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    public class PrimaryAssigneeViewModel
    {
        public int TicketId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string StatusName { get; set; } = string.Empty;
        public string PrimaryTechnician { get; set; } = "Unassigned";
    }
}