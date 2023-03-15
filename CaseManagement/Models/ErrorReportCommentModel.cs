﻿namespace CaseManagement.Models;

internal class ErrorReportCommentModel
{
    public int Id { get; set; }
    public string ErrorReportComment { get; set; } = null!;
    public DateTime ErrorReportCommentDate { get; set; } = DateTime.Now;
    public string ErrorReportDescription { get; set; } = null!;
    public string ErrorReportStatus { get; set; } = null!;
}
