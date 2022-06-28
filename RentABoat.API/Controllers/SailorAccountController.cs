using Microsoft.AspNetCore.Mvc;
using RentABoat.Core.DTO;
using RentABoat.Core.Services;

namespace RentABoat.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SailorAccountController : ControllerBase
{
    private readonly ISailorAccountService _sailorAccountService;

    public SailorAccountController(ISailorAccountService sailorAccountService)
    {
        _sailorAccountService = sailorAccountService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateNewSailorAccount([FromBody] SailorCreationRequestDto dto)
    {
        await _sailorAccountService.AddNewSailorAccountAsync(dto);
        return NoContent();
    }
}
