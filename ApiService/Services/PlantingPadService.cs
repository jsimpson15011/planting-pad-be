using ApiService.Models;
using Microsoft.EntityFrameworkCore;
using ApiService.Dtos;

namespace ApiService.Services;

public class PlantingPadService : IPlantingPadService
{
    private readonly ApplicationDbContext _context;

    public PlantingPadService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<PlantingPad?>> GetAllAsync()
    {
        return await _context.PlantingPads.ToListAsync();
    }

    public async Task<PlantingPad?> GetByIdAsync(Guid id)
    {
        return await _context.PlantingPads.FirstOrDefaultAsync(x => x != null && x.Id == id);
    }

    public async Task<PlantingPad> AddAsync(CreatePlantingPadDto plantingPadDto)
    {
        PlantingPad plantingPad = new PlantingPad
        {
            UserId = null!,
            User = null!,
            Name = plantingPadDto.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
        _context.PlantingPads.Add(plantingPad);
        await _context.SaveChangesAsync();
        return plantingPad;
    }

    public async Task<bool> UpdateAsync(PlantingPad plantingPad)
    {
        var existingPlantingPad = await _context.PlantingPads.FindAsync(plantingPad.Id);
        if (existingPlantingPad == null) return false;
        existingPlantingPad.Name = plantingPad.Name;
        existingPlantingPad.UpdatedAt = DateTime.UtcNow;
        
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var plantingPadToDelete = await _context.PlantingPads.FirstOrDefaultAsync(x => x != null && x.Id == id);
        if (plantingPadToDelete == null) return false;
        _context.PlantingPads.Remove(plantingPadToDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}