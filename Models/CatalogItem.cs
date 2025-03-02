using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace plantingPadBE.Models;

public class CatalogItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();

    [MaxLength(255)] public string Name { get; set; } = string.Empty;
    public bool IsPublic { get; set; }
    public bool IsApproved { get; set; }
    public bool IsVerified { get; set; }
}