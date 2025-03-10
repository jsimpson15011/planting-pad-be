using ApiService.Dtos;
using ApiService.Models;

namespace ApiService.Services;

public interface IPlantingPadService
{
    Task<IEnumerable<PlantingPad?>> GetAllAsync();
    Task<PlantingPad?> GetByIdAsync(Guid id);
    Task<PlantingPad> AddAsync(CreatePlantingPadDto plantingPadDto);
    Task<bool> UpdateAsync(PlantingPad plantingPad);
    Task<bool> DeleteAsync(Guid id);
}