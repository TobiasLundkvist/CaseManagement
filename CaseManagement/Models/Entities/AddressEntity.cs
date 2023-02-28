using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseManagement.Models.Entities;

internal class AddressEntity
{
    [Key]
    [Required]
    public int AddressId { get; set; }

    [Required]
    [StringLength(50)]
    public string StreetName { get; set; } = null!;

    [Required]
    [StringLength(5)]
    public string StreetNumber { get; set; } = null!;

    [Required]
    [Column(TypeName = "char(5)")]
    public string PostalCode { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string City { get; set; } = null!;


    //Relation to Member
    public ICollection<MemberEntity> Members = new HashSet<MemberEntity>();
}
