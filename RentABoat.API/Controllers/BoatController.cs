using Microsoft.AspNetCore.Mvc;
using RentABoat.Core.DTO;
using RentABoat.Core.Services;
using RentABoat.Infrastructure.Entities;

namespace RentABoat.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoatController : ControllerBase
{
    private readonly IBoatService _boatService;

    public BoatController(IBoatService boatService)
    {
        _boatService = boatService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateNewBoat([FromBody] BoatCreationRequestDto dto)
    {
        await _boatService.AddNewBoatAsync(dto);
        return NoContent();
    }
}
