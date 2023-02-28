using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseManagement.Models.Entities;


[Index(nameof(Email), IsUnique = true)]
internal class MemberEntity
{
    [Key]
    [Required]
    public int MemberId { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [Required]
    [StringLength(150)]
    public string Email { get; set; } = null!;

    [Column(TypeName = "char(13)")]
    public string? Phone { get; set; }


    //Relation to Address
    [Required]
    public int AddressId { get; set; }
    public AddressEntity Address { get; set; } = null!;


    //Relation to Reports
    public ICollection<ErrorReportEntity> ErrorReport = new HashSet<ErrorReportEntity>();

}
