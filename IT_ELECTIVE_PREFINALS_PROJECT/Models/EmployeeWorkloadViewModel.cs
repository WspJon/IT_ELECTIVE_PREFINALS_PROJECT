namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    public class EmployeeWorkloadViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public int ActiveTicketCount { get; set; }
    }
}