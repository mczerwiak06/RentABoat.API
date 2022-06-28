using RentABoat.Core.DTO;

namespace RentABoat.Core.Services;

public interface ISailorAccountService
{
    Task<IEnumerable<SailorAccountBasicInformationResponseDto>> GetAllSailorsBasicInformationAsync();
    Task AddNewSailorAccountAsync(SailorCreationRequestDto dto);
}