using System.ComponentModel.DataAnnotations;

namespace CaseManagement.Models.Entities;

internal class ErrorReportEntity
{
    [Key]
    [Required]
    public int ErrorReportId { get; set; }

    [Required]
    public DateTime ErrorReportDate { get; set; }

    public DateTime? ErrorReportDueDate { get; set; }

    [Required]
    [StringLength(150)]
    public string ErrorReportDescription { get; set; } = null!;

    [Required]
    [StringLength(20)]
    public string ErrorReportStatus { get; set; } = null!;

    
    //Relation to Member
    [Required]
    public int MemberId { get; set; }
    public MemberEntity Member { get; set; } = null!;

    //Relation to ErrorReportComment
    public ICollection<ErrorReportCommentEntity> errorReportComments = new HashSet<ErrorReportCommentEntity>();
}
