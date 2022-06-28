using RentABoat.Core.DTO;
using RentABoat.Infrastructure.Entities;
using RentABoat.Infrastructure.Repository;

namespace RentABoat.Core.Services;

public class SailorAccountService : ISailorAccountService
{
    private readonly ISailorAccountRepository _accountRepository;

    public SailorAccountService(ISailorAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    public async Task<IEnumerable<SailorAccountBasicInformationResponseDto>> GetAllSailorsBasicInformationAsync()
    {
        var sailors = await _accountRepository.GetAllAsync();

        return sailors.Select(x => new SailorAccountBasicInformationResponseDto(
            x.FirstName,
            x.LastName,
            x.Email,
            x.PhoneNumber,
            x.Street,
            x.City,
            x.ZipCode,
            x.BuildingNumber));
    }

    public async Task AddNewSailorAccountAsync(SailorCreationRequestDto dto)
    {
        await _accountRepository.AddAsync(new SailorAccount
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            Street = dto.Street,
            City = dto.City,
            ZipCode = dto.ZipCode,
            BuildingNumber = dto.BuildingNumber,
            DateOfCreation = DateTime.UtcNow,
            DateOfUpdate = DateTime.UtcNow
        });
    }
}