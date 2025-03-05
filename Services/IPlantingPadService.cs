using plantingPadBE.Models;

namespace plantingPadBE.Services;

public interface IPlantingPadService
{
    Task<IEnumerable<PlantingPad?>> GetAllAsync();
    Task<PlantingPad?> GetByIdAsync(Guid id);
    Task<PlantingPad> AddAsync(PlantingPad plantingPad);
    Task<bool> UpdateAsync(PlantingPad plantingPad);
    Task<bool> DeleteAsync(Guid id);
}