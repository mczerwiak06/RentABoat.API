using RentABoat.Core.DTO;

namespace RentABoat.Core.Services;

public interface IBoatService
{
    Task<IEnumerable<BoatBasicInformationResponseDto>> GetAllBoatsBasicInformationAsync();
    Task<IEnumerable<BoatBasicInformationResponseDto>> GetBoatsAsync(string type);

    Task AddNewBoatAsync(BoatCreationRequestDto dto);
    Task AddBoatToSailorAccount(int boatToAddId, int sailorAccountId);
}
