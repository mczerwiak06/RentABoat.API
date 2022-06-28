using RentABoat.Core.DTO;

namespace RentABoat.Core.Services;

public interface IBoatService
{
    Task<IEnumerable<BoatBasicInformationResponseDto>> GetAllApartmentBasicInformationAsync();
    Task<BoatBasicInformationResponseDto> GetSailBoatsAsync();

    Task AddNewBoatAsync(BoatCreationRequestDto dto);
}