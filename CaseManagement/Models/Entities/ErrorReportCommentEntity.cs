using System.ComponentModel.DataAnnotations;

namespace CaseManagement.Models.Entities;

internal class ErrorReportCommentEntity
{
    [Key]
    [Required]
    public int ErrorReportCommentId { get; set; }

    [Required]
    [StringLength(150)]
    public string ErrorReportComment { get; set; } = null!;

    [Required]
    public DateTime ErrorReportCommentDate { get; set; }



    //Relation to ErrorReport
    public int ErrorReportId { get; set; }
    public ErrorReportEntity ErrorReport { get; set; } = null!;
}
