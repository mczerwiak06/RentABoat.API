using Microsoft.AspNetCore.Mvc;
using RentABoat.Core.DTO;
using RentABoat.Core.Services;
using RentABoat.Infrastructure.Entities;
using RentABoat.Infrastructure.Repository;

namespace RentABoat.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SailorAccountController : ControllerBase
{
    private readonly ISailorAccountRepository _sailorAccountRepository;
    private readonly ISailorAccountService _sailorAccountService;

    public SailorAccountController(ISailorAccountService sailorAccountService,
        ISailorAccountRepository sailorAccountRepository)
    {
        _sailorAccountService = sailorAccountService;
        _sailorAccountRepository = sailorAccountRepository;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateNewSailorAccount([FromBody] SailorCreationRequestDto dto)
    {
        await _sailorAccountService.AddNewSailorAccountAsync(dto);
        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _sailorAccountService.GetAllSailorsBasicInformationAsync());
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _sailorAccountRepository.GetByIdAsync(id));
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteSailorAccount(int id)
    {
        await _sailorAccountRepository.DeleteByIdAsync(id);
        return NoContent();
    }
}
