using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace plantingPadBE.Models;

public class PlantingPadVersion
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PlantingPadId { get; set; } // Foreign Key to PlantingPad
    [MaxLength(255)]
    public string VersionNumber { get; set; } = string.Empty;
    public string SerializedData { get; set; } = string.Empty;// Serialized JSON of PlantingPad
    public DateTime CreatedAt { get; set; }
    
    public required PlantingPad PlantingPad { get; set; }

}