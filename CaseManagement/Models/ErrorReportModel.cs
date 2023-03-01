namespace CaseManagement.Models;

internal class ErrorReportModel
{
    public int Id { get; set; }
    public DateTime ErrorReportDate { get; set; } = DateTime.Now;
    public DateTime ErrorReportDueDate { get; set; } = DateTime.Now.AddDays(7);
    public string ErrorReportDescription { get; set; } = null!;
    public string ErrorReportStatus { get; set; } = null!;

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
}
