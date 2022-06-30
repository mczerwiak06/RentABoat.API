using RentABoat.Core.DTO;
using RentABoat.Infrastructure.Entities;
using RentABoat.Infrastructure.Exceptions;
using RentABoat.Infrastructure.Repository;

namespace RentABoat.Core.Services;

public class BoatService : IBoatService
{
    private readonly IBoatRepository _boatRepository;
    private readonly ISailorAccountRepository _sailorAccountRepository;

    public BoatService(IBoatRepository boatRepository, ISailorAccountRepository sailorAccountRepository)
    {
        _boatRepository = boatRepository;
        _sailorAccountRepository = sailorAccountRepository;
    }

    public async Task<IEnumerable<BoatBasicInformationResponseDto>> GetAllBoatsBasicInformationAsync()
    {
        var boats = await _boatRepository.GetAllAsync();

        return boats.Select(x => new BoatBasicInformationResponseDto(
            x.Type,
            x.Length,
            x.NumberOfBerths,
            x.YearOfBuilt,
            x.Model,
            x.Harbour,
            x.IsAvailable));
    }

    public async Task AddNewBoatAsync(BoatCreationRequestDto dto)
    {
        await _boatRepository.AddAsync(new Boat
        {
            Type = dto.Type,
            Length = dto.Length,
            NumberOfBerths = dto.NumberOfBerths,
            YearOfBuilt = dto.YearOfBuilt,
            Model = dto.Model,
            Harbour = dto.Harbour,
            IsAvailable = dto.IsAvailable,
            DateOfCreation = DateTime.UtcNow,
            DateOfUpdate = DateTime.UtcNow
        });
    }

    public async Task<IEnumerable<BoatBasicInformationResponseDto>> GetBoatsAsync(string type)
    {
        var boats = await _boatRepository.GetAllAsync();
        var boatsToSearch = boats.Where(x => x.Type == type);

        return boatsToSearch.Select(x => new BoatBasicInformationResponseDto(
            x.Type,
            x.Length,
            x.NumberOfBerths,
            x.YearOfBuilt,
            x.Model,
            x.Harbour,
            x.IsAvailable));
    }

    public async Task AddBoatToSailorAccount(int boatToRentId, int sailorAccountId)
    {
        var sailor = await _sailorAccountRepository.GetByIdAsync(sailorAccountId);
        var boatTaAdd = await _boatRepository.GetByIdAsync(boatToRentId);
        if (boatTaAdd.IsAvailable == false || sailor.BoatId != null) throw new BoatOrSailorOccupiedException();
        sailor.BoatId = boatTaAdd.Id;
        boatTaAdd.SailorAccountId = sailor.Id;
        boatTaAdd.IsAvailable = false;
        await _boatRepository.UpdateAsync(boatTaAdd);
        await _sailorAccountRepository.UpdateAsync(sailor);
    }
}
