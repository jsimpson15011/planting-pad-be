using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace plantingPadBE.Models;

public class CanvasItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();

    [MaxLength(255)] public string Name { get; set; } = string.Empty;
    public float X { get; set; }
    public float Y { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public float BufferHeight { get; set; }
    public float BufferWidth { get; set; }

    [ForeignKey("CatalogItemId")] public Guid CatalogItemId { get; set; }
    [ForeignKey("PlantingPadId")] public Guid PlantingPadId { get; set; }
}
