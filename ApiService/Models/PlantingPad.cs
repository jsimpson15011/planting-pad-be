using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AuthService.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiService.Models;

public class PlantingPad
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();

    [MaxLength(255)] public string Name { get; set; } = string.Empty;

    // Foreign Key to the Identity User
    [ForeignKey("User")]
    [Required]
    [MaxLength(450)]
    public required string UserId { get; set; }
    
    public DbSet<CanvasItem>? CanvasItems { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public DbSet<PlantingPadVersion>? Versions { get; set; }
}

