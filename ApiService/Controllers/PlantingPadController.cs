using ApiService.Dtos;
using ApiService.Models;
using ApiService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers;

[ApiController]
[Route("[controller]")]
public class PlantingPadController : ControllerBase
{
    private readonly IPlantingPadService _plantingPadService;
    
    public PlantingPadController(IPlantingPadService plantingPadService)
    {
        _plantingPadService = plantingPadService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlantingPad>>> GetAll()//todo add user check to only get the current user's pads
    {
        var plantingPads = await _plantingPadService.GetAllAsync();
        return Ok(plantingPads);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlantingPad>> GetById(Guid id)
    {
        var plantingPad = await _plantingPadService.GetByIdAsync(id);
        if (plantingPad == null)
        {
            return NotFound();
        }
        
        return Ok(plantingPad);
    }
    
    [HttpPost]
    public async Task<ActionResult<PlantingPad>> Add(CreatePlantingPadDto createPlantingPadDto)
    {
        var newPlantingPad = await _plantingPadService.AddAsync(createPlantingPadDto);
        return CreatedAtAction(nameof(GetById), new {id = newPlantingPad.Id}, newPlantingPad);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<PlantingPad>> Update(Guid id, PlantingPad plantingPad)
    {
        if (id != plantingPad.Id)
        {
            return BadRequest();
        }
        var updatedPlantingPad = await _plantingPadService.UpdateAsync(plantingPad);
        if (updatedPlantingPad == false)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<PlantingPad>> Delete(Guid id)
    {
        var deletedPlantingPad = await _plantingPadService.DeleteAsync(id);
        if (deletedPlantingPad == false)
        {
            return NotFound();
        }
        return NoContent();
    }
}