using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace plantingPadBE.Models;

public class ApplicationDbContext : IdentityDbContext<PlantingPadIdentity>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}
    
    public DbSet<PlantingPad?> PlantingPads { get; set; }
    
    public DbSet<CanvasItem> CanvasItems { get; set; }
    
    public DbSet<CatalogItem> CatalogItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // TPH configuration
        modelBuilder.Entity<CatalogItem>()
            .HasDiscriminator<string>("ItemType") // Add Discriminator Column
            .HasValue<CatalogItem>("CatalogItem")     // Default value for base class
            .HasValue<Plant>("Plant");               // Value for derived class
        
        modelBuilder.Entity<CatalogItem>()
            .Property("ItemType")
            .HasMaxLength(50);
        
        modelBuilder.Entity<PlantingPadVersion>()
            .HasOne(v => v.PlantingPad)
            .WithMany(p => p.Versions)
            .HasForeignKey(v => v.PlantingPadId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<CanvasItem>()
            .HasOne<PlantingPad>()
            .WithMany(p => p.CanvasItems)
            .HasForeignKey(c => c.PlantingPadId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }

}