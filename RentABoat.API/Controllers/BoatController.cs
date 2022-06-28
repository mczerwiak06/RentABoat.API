using Microsoft.AspNetCore.Mvc;
using RentABoat.Core.DTO;
using RentABoat.Core.Services;
using RentABoat.Infrastructure.Repository;

namespace RentABoat.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoatController : ControllerBase
{
    private readonly IBoatRepository _boatRepository;
    private readonly IBoatService _boatService;

    public BoatController(IBoatService boatService, IBoatRepository boatRepository)
    {
        _boatService = boatService;
        _boatRepository = boatRepository;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateNewBoat([FromBody] BoatCreationRequestDto dto)
    {
        await _boatService.AddNewBoatAsync(dto);
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _boatService.GetAllBoatsBasicInformationAsync());
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _boatRepository.GetByIdAsync(id));
    }

    [HttpGet("GetByType/{type}")]
    public async Task<IActionResult> GetByType(string type)
    {
        return Ok(await _boatService.GetBoatsAsync(type));
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteBoat(int id)
    {
        await _boatRepository.DeleteByIdAsync(id);
        return NoContent();
    }
}
